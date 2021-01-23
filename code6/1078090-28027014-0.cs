            string wordToSearch = "HereIsTheWord";
            string characterToFind = "e";
            int currentIndex = 0;
            List<int> indexes = new List<int>();
            while(currentIndex >= 0)
            {
                currentIndex = wordToSearch.IndexOf(characterToFind, currentIndex + 1);
                if (currentIndex >= 0)
                {
                    indexes.Add(currentIndex);
                }
            }
            for (int index = 0; index < indexes.Count; index += 1)
            {
                Console.WriteLine(indexes[index]);
            }
