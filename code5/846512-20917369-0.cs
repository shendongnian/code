     var locId = Convert.ToInt32(e.CommandArgument);
             foreach (TreeNode node in tvLocations.Nodes)
            {
                //level 1
                bool value = false;
                if (value)
                    break;
                if (node.Value == locId.ToString())
                {
                    node.Selected = true;
                    value = true;
                    break;
                }
                else 
                {
                    if (node.ChildNodes.Count > 0)
                    {     //level 2
                        foreach (TreeNode subchild in node.ChildNodes)
                        {
                            if (value)
                                break;
                            if (subchild.Value == locId.ToString())
                            {
                                subchild.Selected = true;
                                value = true;
                                break;
                            }
                            else
                            {
                                if (subchild.ChildNodes.Count > 0)
                                { 
                                    //level 3
                                    foreach (TreeNode subchild1 in subchild.ChildNodes)
                                    {
                                        if (value)
                                            break;
                                        if (subchild1.Value == locId.ToString())
                                        {
                                            subchild1.Selected = true;
                                            value = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (subchild1.ChildNodes.Count > 0)
                                            {
                                                //level 4
                                                foreach (TreeNode subchild2 in subchild1.ChildNodes)
                                                {
                                                    if (value)
                                                        break;
                                                    if (subchild2.Value == locId.ToString())
                                                    {
                                                        subchild2.Selected = true;
                                                        value = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (subchild2.ChildNodes.Count > 0)
                                                        {
                                                            //level 5
                                                            foreach (TreeNode subchild3 in subchild2.ChildNodes)
                                                            {
                                                                if (value)
                                                                    break;
                                                                if (subchild3.Value == locId.ToString())
                                                                {
                                                                    subchild3.Selected = true;
                                                                    value = true;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                          
                        }
                    }
                }
            }
