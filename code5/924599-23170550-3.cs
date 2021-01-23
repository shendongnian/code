            public void LoadDropdownlist()
            {
                var makes = new List<string> {"Volkswagen","Audi","BMW","Ford","Vauxhall"};
                FirstLetterComparer comp = new FirstLetterComparer();
                comboBox1.DataSource=  makes.Distinct(comp).ToList();//makes.GroupBy(x=>x[0]).Select(x=>x.First()).ToList();
            }
            public class FirstLetterComparer : IEqualityComparer<string>
            {
                public bool Equals(string x, string y)
                {
                    if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                        return false;
                    //ignoring case
                    return string.Compare(x[1].ToString(), y[1].ToString(), 0) == 0;
                }
                public int GetHashCode(string str)
                {
                    return 1;
                }
            }
      
