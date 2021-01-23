        public void ChangeAllFiles(String root)
        {
            Stack<String> searchStack = new Stack<string>();
            searchStack.Push(root);
            while (searchStack.Count > 0)
            {
                String path = searchStack.Pop();
                foreach (var file in Directory.GetFiles(path))
                {
                    ChangeFileName(file);
                }
                foreach (var subDir in Directory.GetDirectories(path))
                {
                    searchStack.Push(subDir);
                }
            }
        }
