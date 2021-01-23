        Dictionary<string, string> wordsToReplace = new Dictionary<string, string>();
            wordsToReplace.Add("Test1", "amir");
            wordsToReplace.Add("Test2", "amir1");
            wordsToReplace.Add("Test3", "amir3");
            wordsToReplace.Add("Test4", "amir4");
            wordsToReplace.Add("Test5", "amir5");
            wordsToReplace.Add("Test6", "amir6");
            string strVal = System.IO.File.ReadAllText(Server.MapPath("~/template/xml/xmltest") + ".xml");
           
            foreach (var pair in wordsToReplace)
            {
                //Performs each replacement
                strVal = strVal.Replace(pair.Key, pair.Value);
            }
            File.Copy(Path.Combine(filePath), Path.Combine(filePath2));
            System.IO.File.WriteAllText(Server.MapPath("~/template/xml/xmlback/test2") + ".xml", strVal);
            ProcessRequest(filePath2, Lcourseid.Text);
