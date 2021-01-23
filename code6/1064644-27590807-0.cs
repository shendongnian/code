            public TreeNode RecursiveDirToTree(TreeNode parentNode, string path,
                                     string extension = ".txt")
        {
            var result = new TreeNode(parentNode == null ? path/*base line*/ : System.IO.Path.GetFileName(path));
            foreach (string dir in System.IO.Directory.GetDirectories(path))
            {
                TreeNode node = RecursiveDirToTree(result, dir , extension);
                if (node.Nodes.Count > 0)
                {
                    result.Nodes.Add(node);
                }
            }
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                if (System.IO.Path.GetExtension(file).ToLower() == extension.ToLower())
                {
                    result.Nodes.Add(System.IO.Path.GetFileName(file));
                }
            }
            return result;
        }
