        public bool validateUserInputAgainstWhiteList(String pword)
        {
            // Gets only a string with letters of any size and any amount of numbers
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");
            // if pword does not meet regular expression then return false
            if (!positiveIntRegex.IsMatch(pword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
