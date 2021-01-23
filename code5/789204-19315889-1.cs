    TreeNode pidNode = new TreeNode();
    pidNode.Text = PIDstr;
    foreach (DataRow patrow in ds.Tables["PatientExam"].Rows)
    {
        TreeNode examType = new TreeNode();
        examType.Text = patrow["Exam"].ToString();
        pidNode.Nodes.Add(examType);
    }
 
    TreeView1.Nodes.add(pidNode);
