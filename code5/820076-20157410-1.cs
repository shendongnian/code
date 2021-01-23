      private static IEnumerable<string> Search(string pattern, string root)
        {
            if (!Directory.Exists(root))
            {
                yield return null;
            }
            var paths = new Queue<string>();
            paths.Enqueue(root);
            while (paths.Count > 0)
            {
                root = paths.Dequeue();
                string[] temp = Directory.GetFiles(root, pattern);
                foreach (string t in temp)
                {
                    yield return t;
                }
                temp = Directory.GetDirectories(root);
                foreach (string t in temp)
                {
                    paths.Enqueue(t);
                }
            }
        }
