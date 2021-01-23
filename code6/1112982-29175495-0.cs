            Foo(new TreeNode()
            {
                Text = "test",
                Nodes = new List<TreeNode>()
                {
                    
                    new TreeNode(){Text = "a"},
                    new TreeNode(){
                        Text = "b",
                        Nodes = new List<TreeNode>()
                        {
                    
                            new TreeNode(){Text = "c"},
                            new TreeNode(){Text = "d"},
                        }
                    },
                }
            } );
