            string stringValue = "";            
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (String hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer. 
                if (hex != "")
                {
                    value = Convert.ToInt32(hex, 16);
                    // Get the character corresponding to the integral value. 
                    stringValue += Char.ConvertFromUtf32(value);
                }
            }
            DateTime dt = DateTime.ParseExact(stringValue, "yyyyMMddHHmmss", null);
