     private void bCleanUpTreeView_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> vDic = new Dictionary<string, string>();
            foreach (CustomFruitCrateNode node in treeView1.Nodes)
            {
                foreach (CustomFruitCrateNode childNode in node.Nodes)
                {
                    if (!vDic.ContainsKey(childNode.FruitName))
                    {
                        vdDic.Add(childNode.Location, childNode.FruitName);
                    }
                    else
                    {
                        childNode.Remove();
                    }
                }
            }
        }
