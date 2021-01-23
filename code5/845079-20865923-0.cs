     if (r == 100)
        {
            
            indexOfCChars = 0
            //The problem occurs here. This loop doesn't stop at the 100th character.
            foreach (char c in a[0].Substring(0, 100))
            {
                indexOfCChars++;
                if (c == ' ')
                {
                    indexOfSpaces++;
                    indexPointOfSplit = indexOfCChars;
                    MessageBox.Show(indexPointOfSplit.ToString());
                }
            }
        }
