        private bool ValidateUserName(string Name)
        {
            bool temp = false;
            if (Name.All(char.IsLetterOrDigit) && Name.Any(char.IsDigit) && !Name.All(char.IsDigit)) temp = true;
            return temp;
        }
