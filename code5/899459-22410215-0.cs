            using (StreamReader reader = new StreamReader(@"c:\csharp\file.txt"))
            {
                bool stillReading = true;
                do
                {
                    string card, numBorrowed;
                    card = reader.ReadLine();
                    numBorrowed = reader.ReadLine();
                    if (card != null && numBorrowed != null)
                    {
                        int numB;
                        Card newcard = new Card
                        {
                            CardName = card,
                            NumBorrowed = Int32.TryParse(numBorrowed, out numB) ? numB : 0
                        };
                        cardlist.Add(newcard);
                    }
                    else
                    {
                        stillReading = false;
                    }
                } while (stillReading);
            }
