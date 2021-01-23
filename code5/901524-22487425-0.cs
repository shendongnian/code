    private void GenerateTreeView()
        {
            string[] terms = { "HR;Vocation", "Home", "Stations;Europe", 
                             "Teams;Team1", "Teams;Team2", 
                             "Teams;Team3", "Teams", "Stations;Africa", "Stations", "HR", "HR;Economy", "Stations;Asia","HR;Economy;Test" };
            Array.Sort(terms);
            foreach(string strTerm in terms)
            {
                string[] strSubTerm = strTerm.Split(';');
                if (strSubTerm.Length < 2)
                {
                    treeView1.Nodes.Add(new TreeNode(strTerm));
                }
                else
                {
                    try
                    {
                        if (strSubTerm.Length > 2)
                        {
                            treeView1.FindNode(strSubTerm[0] +"/" +strSubTerm[1]).ChildNodes.Add(new TreeNode(strSubTerm[strSubTerm.Length - 1]));
                            continue;
                        }
                        treeView1.FindNode(strSubTerm[0]).ChildNodes.Add(new TreeNode(strSubTerm[strSubTerm.Length - 1]));
                    }
                    catch
                    {
                        
                    }
                }
            }
        }
