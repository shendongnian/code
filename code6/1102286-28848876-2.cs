    foreach (TreeNode node in treeView1.Nodes) RecurseTree(node);
    private void RecurseTree(TreeNode node)
	{
		if (node.Checked == true)
		{
			switch (node.Name)
			{
				case "Trial A":
					//execute code for Trial A
					MessageBox.Show("A"); //trial
					break;
				case "Trial B":
					//execute code for Trial B
					MessageBox.Show("B"); //trial
					break;
				case "Trial C":
					//execute code for Trial C
					MessageBox.Show("C"); //trial
					break;
				default:
					MessageBox.Show("error");
					break;
			}
		}
		foreach (TreeNode childNode in node.Nodes) RecurseTree(childNode);
	}
