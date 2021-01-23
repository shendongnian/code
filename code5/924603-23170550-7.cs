        public List<string> FetchFirstLetterUniques(List<string> source)
        {
            List<string> result = new List<string>();
            foreach (string item in source)
            {
                bool isAdded = false;
               foreach (string item2 in result)
               {
                   if (string.Compare(item2[0].ToString(), item[0].ToString(), 0) == 0)
                   {
                       isAdded = true;
                       break;
                   }
               }
               if (!isAdded)
                   result.Add(item);
                
            }
            return result;
        }
    public void LoadDropdownlist()
    {
        var makes = new List<string> {
                                       "Audi",
                                       "BMW",
                                       "Ford",
                                       "Vauxhall",
                                       "Volkswagen"
                                     };
        comboBox1.DataSource = FetchFirstLetterUniques(makes);
    }
