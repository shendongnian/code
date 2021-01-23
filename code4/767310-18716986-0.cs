        public string SplitName(string text)
        {
            string forename = string.Empty;
            string middlename = string.Empty;
            string surname = string.Empty;
            var name = text.Split(' ');
            if (name != null)
            {
                if (name.Length > 2)
                {
                    forename = name[0];
                    surname = name[name.Length - 1];
                    List<string> temp = new List<string>();
                    for (int i = 1; i < name.Length - 1; i++)
                    {
                        middlename += name[i];
                    }
                    text = string.Format("{0} {1} {2}", forename, middlename, surname);
                }
            }
            else
            {
                text = "INVALID";
            }
            return text;
        }
