            List<string> result = new List<string>();
            string testString = "This is a test string";
            string chunkBuilder = "";
            int chunkSize = 5;
            for (int i = 0; i <= testString.Length-1; i++)
            {
                chunkBuilder += testString[i];
                if (chunkBuilder.Length == chunkSize || i == testString.Length - 1)
                {
                    result.Add(chunkBuilder);
                    chunkBuilder = "";
                }
            }
