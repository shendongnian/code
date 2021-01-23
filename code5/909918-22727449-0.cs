                IList<int> arr = Enumerable.Range(1, 99).ToList();
                int randNum;
                Random rnd = new Random();
                randNum = rnd.Next(1, arr.Count());
                MessageBox.Show(randNum.ToString());
                arr = arr.Where(x => x != randNum).ToList();
