            List<string> values = new List<string> { "item1", "item1", "item1" };
            values.Sort();
            string previousValue = string.Empty; 
            int number = 1; 
            for(int i = 0 ; i < values.Count; i ++) 
            {
                if (values[i].Equals(previousValue))
                {
                    previousValue = values[i]; 
                    values[i] = values[i] + "-" + number;
                    number++;
                }
                else
                {
                    previousValue = values[i]; 
                    number = 1; 
                }
                
            }
