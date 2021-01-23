            string words = "word 7, word 8, word 9, word 14";
            string[] splittedWords = Regex.Split(words, ", "); //Separating words.
            List<string> sortedWords = new List<string>();
            int currentWordNumber = 0, lastWordNumber = 0;
            foreach (string sptw in splittedWords)
            {
                if (sortedWords.Count == 0) //No value has been written to the list yet, so:
                {
                    sortedWords.Add(sptw);
                    lastWordNumber = int.Parse(sptw.Split(' ')[1]); //Storing the number of the word for checking it later.
                }
                else
                {
                    currentWordNumber = int.Parse(sptw.Split(' ')[1]);
                    if (currentWordNumber == lastWordNumber + 1)
                        sortedWords[sortedWords.Count - 1] += ", " + sptw;
                    else
                        sortedWords.Add(sptw);
                    lastWordNumber = currentWordNumber; //Storing the number of the word for checking it later.
                }
            }
