    //Построение дерева файловой системы ftp сервера 
    private static void ListDirectory(TreeView treeView, string Host, string UserName, string password)
    {
        Ftp_Client ftp = new Ftp_Client();
        ftp.Host = Host;
        ftp.UserName = UserName;
        ftp.Password = password;
        treeView.Nodes.Clear();
        var stack = new Stack<TreeNode>();
        var rootDirectory = DOMAIN;
        var node = new TreeNode(rootDirectory) { Tag = "/" };
        stack.Push(node);
        while (stack.Count > 0)
        {
            try
            {
                var currentNode = stack.Pop();
                var directoryInfo = ftp.ListDirectory((string)currentNode.Tag);
                foreach (var directory in directoryInfo)
                {
                    if (directory.IsDirectory && directory.Name!="?") {
                        var childDirectoryNode = new TreeNode(directory.Name) { Tag = currentNode.Tag+directory.Name+'/'};
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                }
                foreach (var file in directoryInfo)
                    if (!file.IsDirectory && file.Name != "?")
                        currentNode.Nodes.Add(new TreeNode(file.Name) { Tag = currentNode.Tag + file.Name + "/f"}); ; //пометка f в конце пути означает, что это файл!
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        treeView.Nodes.Add(node);
    }
