             String subjectString = "A12345 EF12345 C67890 AB12345 CD67890";
            string[] ssize = subjectString.Split(null);
            try
            {
                for (int i = 0; i <= ssize.Length; i++)
                {
                    Regex regexObj = new Regex("[A-Z]{2}[0-9]{5}", RegexOptions.IgnoreCase);
                    Match matchResults = regexObj.Match(ssize[i]);
                    if (matchResults.Success)
                    {
                        label.Text += " ";
                        label.Text += matchResults.Value.ToString();
                    }
                }
            }
