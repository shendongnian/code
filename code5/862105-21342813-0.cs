            List<string> values = new List<string> { "item1", "item2", "item1" };
            values.Sort();
            string previousValue = string.Empty; 
            int number = 1; 
            for(int i = 0 ; i < values.Count; i ++) 
            {
                if (values[i].Equals(previousValue))
                {
                    values[i] = values[i] + "-" + number;
                    number++;
                }
                else
                {
                    number = 1; 
                }
                previousValue = values[i]; 
            }
