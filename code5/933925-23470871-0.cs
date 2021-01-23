    TreeNode SessionNode = new TreeNode("Current Session");
            //Add Tag object to the new node
            NodeTag nt = new NodeTag();
            nt.NodeName = "SESS";
            nt.NodeNumber = 0;
            SessionNode.Tag = (object) nt;
            tv_project.Nodes.Add(SessionNode);
            MainProject.ProjectNode = new TreeNode("Project - " + e.ProjName + " - " + e.ProjOwner);
            //Add Tag object to the new node
            NodeTag nt1 = new NodeTag();
            nt1.NodeName = "PROJ";
            nt1.NodeNumber = 0;
            MainProject.ProjectNode.Tag = (object) nt1;
            SessionNode.Nodes.Add(MainProject.ProjectNode);
            TreeNode SettingsNode = new TreeNode("Global Settings");
            //Add Tag object to the new node
            NodeTag nt2 = new NodeTag();
            nt2.NodeName = "GLBS";
            nt2.NodeNumber = 0;
            SettingsNode.Tag = (object) nt2;
            SettingsNode.ForeColor = Color.Red;
            MainProject.ProjectNode.Nodes.Add(SettingsNode);
  
