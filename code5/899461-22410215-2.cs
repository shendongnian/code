            using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
            {
                bool stillReading = true;
                while (stillReading)
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
                } 
            }
