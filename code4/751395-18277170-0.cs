        private string GetFileName(string path)
        {
            string filename = null;
            for (int i = (path.Length - 1); i > -1; --i)
            {
                if (path[i].ToString() == "/")
                {
                    for (int x = (i + 1); x < (path.Length); ++x)
                    {
                        filename += path[x];
                    }
                    break;
                }
            }
            return (filename);
        }
