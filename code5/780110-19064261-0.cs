    Array drivesList= DriveInfo.GetDrives(); 
    for (int index = 0; index < drivesList.GetLength(0); index++) 
    { 
      string text = drivesList.GetValue(index).ToString(); 
      TreeNode parentNode = new TreeNode(text); 
      parentNode.PopulateOnDemand = true; 
      TreeView1.Nodes.Add(parentNode); 
    }
