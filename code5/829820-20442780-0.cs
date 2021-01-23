        public static void SaveTree(TreeView tree)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, tree.Nodes.Cast<TreeNode>().ToList());
                Properties.Settings.Default.tree = Convert.ToBase64String(ms.ToArray());
                Properties.Settings.Default.Save();
            }
        }
        public static void LoadTree(TreeView tree)
        {
            byte[] bytes = Convert.FromBase64String(Properties.Settings.Default.tree);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                var data =  new BinaryFormatter().Deserialize(ms);
                tree.Nodes.AddRange(((List<TreeNode>)data).ToArray());
            }
        }
