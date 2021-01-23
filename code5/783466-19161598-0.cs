        private void getFiles(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            string[] directories = Directory.GetDirectories(directory);
            foreach (string file in files)
            {
                // Code here.
            }
            foreach (string subDirectory in directories)
            {
                // Call the same method on each directory.
                getFiles(subDirectory);
            }
        }
