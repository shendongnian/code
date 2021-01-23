            int vowelCount = 0;
            int digitCount = 0;
            string inputString;
            inputString = this.entryTextBox.Text.ToLower();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            string vow = new string(vowels);
            for (int index = 0; index < inputString.Length; index++)
            {
                if (char.IsLetterOrDigit(inputString[index]))
                {
                    if (vow.Contains(inputString[index]))
                    {
                        vowelCount++;
                    }
                }
                else if (char.IsDigit(inputString[index]))
                    digitCount++;
            }
            this.voweldisplayLabel.Text = vowelCount.ToString();
            this.digitsdisplayLabel.Text = digitCount.ToString();
