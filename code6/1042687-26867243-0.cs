           //populating treeView with dummy data
       private void Form2_Load(object sender, EventArgs e)
            {
                //set the check box true
                treeView1.CheckBoxes = true;
                TreeNode treeNode = new TreeNode("Windows");
                treeView1.Nodes.Add(treeNode);
                //
                // Another node following the first node.
                //
                treeNode = new TreeNode("Linux");
                treeView1.Nodes.Add(treeNode);
                //
                // Create two child nodes and put them in an array.
                // ... Add the third node, and specify these as its children.
                //
                TreeNode node2 = new TreeNode("C#");
                TreeNode node3 = new TreeNode("VB.NET");
                TreeNode[] array = new TreeNode[] { node2, node3 };
                //
                // Final node.
                //
                treeNode = new TreeNode("Dot Net Perls", array);
                treeView1.Nodes.Add(treeNode);
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
               
               string text = traverseTreeAngGetName(treeView1.Nodes);
               this.richTextBox1.SelectedText = text;
               
            }
            /// <summary>
            /// it will traverse all the tree Node from 1 to N Level. if Node is Checked then get
            /// the checked node name.
            /// </summary>
            /// <param name="tr"></param>
            /// <returns></returns>
            public static string traverseTreeAngGetName(TreeNodeCollection tr){
             
                string str = "";
    
                foreach (TreeNode node in tr) {
                   
                    if (node.Checked) {
                        //here you can append any text on the base of current
                        str += node.Text + " - " ;
                    }
                    str += traverseTreeAngGetName(node.Nodes);
                }
                return str;
            }
