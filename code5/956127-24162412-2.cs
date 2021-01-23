            string input = DateTime.Now.ToString("yyyyMMddHHmmss");
            string hexValues = "";
            int value = 0;
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                hexValues += String.Format("{0:X}", value);
                hexValues += " ";
            }
