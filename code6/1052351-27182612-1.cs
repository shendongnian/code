            string solutionFile="the solution file";FileInfo fInfo = new FileInfo(solutionFile);
            string solutionText = File.ReadAllText(solutionFile);
            Regex reg = new Regex("Project\\(\"[^\"]+\"\\) = \"[^\"]+\", \"([^\"]+)\", \"[^\"]+\"");
            MatchCollection mc = reg.Matches(solutionText);
            List<string> files = new List<string>();
            foreach (Match m in mc)
            {
                string project_file = m.Groups[1].Value;
                project_file = System.IO.Path.Combine(fInfo.Directory.FullName, project_file);
                if (System.IO.File.Exists(project_file))
                {
                    string project_path = new FileInfo(project_file).DirectoryName;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(project_file);                    
                    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                    ns.AddNamespace("ms", "http://schemas.microsoft.com/developer/msbuild/2003");
                    System.Xml.XmlNodeList list = doc.ChildNodes[1].SelectNodes("//ms:ItemGroup/ms:Compile", ns);
                    foreach (XmlNode node in list)
                    {
                        files.Add(Path.Combine(project_path, node.Attributes["Include"].InnerText));
                    }
                }
            }
