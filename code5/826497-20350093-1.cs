       string result = string.Empty;
            var array = dec.ToString().Split('.');
            if (dec > 0)
            {
                
                result = array[0].PadLeft(9).Remove(0, 9);
                if (array.Count() > 1)
                {
                    result += '.' + array[1].PadRight(3).Remove(3);
                }
            }
            else
            {
                
                result = "-"+array[0].PadLeft(9).Remove(0, 9);
                if (array.Count() > 1)
                {
                    result += '.' + array[1].PadRight(3).Remove(3);
                }
                
            }
