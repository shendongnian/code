    I have applied treeview nodes populated with multiple childs in one of my work, hence it can give you an idea: 
    int k=0,L=0,totalNode=0;
                for (int j = 0; j < ((object[])(row[0, 0])).Length; j++) {
    
                    TreeNode root = new TreeNode();  // Creating new root node
                    root.Text = ((object[])(row[0, 1]))[j].ToString()+" "; 
                    root.Tag = ((object[])(row[0, 0]))[j].ToString();
                    int projectID = Convert.ToInt32(root.Tag);
                    treeView1.Nodes.Add(root); //Adding the node
                    totalNode++;
    
                    TaskDataHandler taskData = new TaskDataHandler();
                    object[,] arrTask = new object[1, 2];
                    arrTask = taskData.GetTaskData(xdoc, AppVariable.apiToken, projectID);
                    for (int i = 0; i < ((object[])(arrTask[0, 0])).Length; i++) {
                        totalNode++;
                        TreeNode child = new TreeNode(); // creating child node
                        child.Text = ((object[])(arrTask[0, 1]))[i].ToString() + " ";
                        child.Tag = ((object[])(arrTask[0, 0]))[i].ToString();
                        root.Nodes.Add(child); // adding child node
                    }
    
                }
