     private static string Search(string pattern, string root)
        {
            if (!Directory.Exists(root))
            {
                return string.Empty;
            }
            var paths = new Queue<string>();
            paths.Enqueue(root);
            while (paths.Count > 0)
            {
                root = paths.Dequeue();
                string[] temp = Directory.GetFiles(root, pattern);
                foreach (string t in temp)
                {
                    return t;
                }
                temp = Directory.GetDirectories(root);
                foreach (string t in temp)
                {
                    paths.Enqueue(t);
                }
            }
            return string.Empty;
        }
