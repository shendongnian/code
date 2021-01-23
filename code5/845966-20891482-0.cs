            int max = wordslist.Count;
            //find all the indexes using LINQ
            List<int> matches = Enumerable.Range(0, wordslist.Count)
                            .Where(i => wordslist[i] == text.Text)
                            .ToList();
            foreach( int match in matches ) {                
                    if(match - 1 > 0)
                    {
                        Console.WriteLine("\n" + wordslist[match - 1]+ " " + text.Text);
                    }
                    if (match + 1 < max)
                    {
                        Console.WriteLine("\n" + text.Text + " " + wordslist[match + 1]);
                    }
            }
