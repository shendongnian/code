        public string MyFunction(params short[] variables)
        {
            string myString = string.Empty;
            if (variables.Length == 1)
            {
                // logic to handle the single variable
                return myString + variables[0];
            }
            else
            {
                foreach (var z in variables)
                {
                    myString += " " + MyFunction(z);
                }
            }
            return myString;
        }
