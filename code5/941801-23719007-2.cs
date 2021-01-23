        public void findGameDirectories(String startDir)
        {
            DirectoryInfo directory = new DirectoryInfo(startDir);
            foreach (var file in directory.GetFiles("*.exe", SearchOption.AllDirectories))
            {
                foreach (var gameFileName in games)
                {
                    if (file.Name == (gameFileName))
                    {
                        Console.WriteLine("You found " + game.DisplayName);
                    }
                }
            }
        }
