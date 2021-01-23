        public static void GetIterations(TfsTeamProjectCollection collection,
            ICommonStructureService4 css, ProjectInfo project)
        {
            TeamSettingsConfigurationService teamConfigService = collection.GetService<TeamSettingsConfigurationService>();
            NodeInfo[] structures = css.ListStructures(project.Uri);
            NodeInfo iterations = structures.FirstOrDefault(n => n.StructureType.Equals("ProjectLifecycle"));
            XmlElement iterationsTree = css.GetNodesXml(new[] { iterations.Uri }, true);
    
            string baseName = project.Name + @"\";
            BuildIterationTree(iterationsTree.ChildNodes[0].ChildNodes, baseName);
        }
    
        private static void BuildIterationTree(XmlNodeList items, string baseName)
        {
            foreach (XmlNode node in items)
            {
                if (node.Attributes["NodeID"] != null &&
                    node.Attributes["Name"] != null &&
                    node.Attributes["StartDate"] != null &&
                    node.Attributes["FinishDate"] != null)
                {
                    string name = node.Attributes["Name"].Value;
                    DateTime startDate = DateTime.Parse(node.Attributes["StartDate"].Value, CultureInfo.InvariantCulture);
                    DateTime finishDate = DateTime.Parse(node.Attributes["FinishDate"].Value, CultureInfo.InvariantCulture);
                    // Found Iteration with start / end dates
                }
                else if (node.Attributes["Name"] != null)
                {
                    string name = node.Attributes["Name"].Value;
                    // Found Iteration without start / end dates
                }
                if (node.ChildNodes.Count > 0)
                {
                    string name = baseName;
                    if (node.Attributes["Name"] != null)
                        name += node.Attributes["Name"].Value + @"\";
                    BuildIterationTree(node.ChildNodes, name);
                }
            }
        }
