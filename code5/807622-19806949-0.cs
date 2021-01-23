     private  bool IsValid(String input)
            {
                bool isValid = false;
                // Here we call Regex.Match.
                Match match = Regex.Match(input, @"^[^IVXMCDL]*$");
    
                // Here we check the Match instance.
                if (match.Success)
                {
                   isValid = true;
                }
                else
                {
                    isValid = false;
                }
    
              return isValid;
            }
