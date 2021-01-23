        private void SearchString(string searchTerm)
        {
            if (searchTerm.Length <= 0)
            {
                MessageBox.Show("Search term must be atleast a character long.");
                return;
            }
            else
            {
                string[] rows = File.ReadAllLines(@"C:\Users\Aviral Singh\Desktop\Test.txt");
                int counter = 0;
                foreach (string row in rows)
                {
                    if (row == searchTerm)
                    {
                        MessageBox.Show(string.Format("Search term '{0}' was found at row {1} and column {2}.", searchTerm, row.IndexOf(searchTerm), counter));
                    }
                    counter++;
                }
            }
        }
