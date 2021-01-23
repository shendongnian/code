	private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
	{
		TreeNode curNode = addInMe.Add(directoryInfo.Name);
		foreach (FileInfo file in directoryInfo.GetFiles())
		{
			string date = "getyourdatefrom_file";
			TreeNode dateNode = addInMe.Add(date);
			curNode.Nodes.Add(dateNode);
			dateNode.Nodes.Add(file.FullName, file.Name);
		}
		foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
		{
			BuildTree(subdir, curNode.Nodes);
		}
	}
