            string pattern = "dd/MM/yyyy HH:mm:ss";
            DateTime parsedDate;
            string dateValue = "27/11/2014 17:35:59";
            if (DateTime.TryParseExact(dateValue, pattern, null,
                                      DateTimeStyles.None, out parsedDate))
            {
                MessageBox.Show(string.Format("Converted '{0}' to {1:d}.", dateValue, parsedDate));
            }
            else
            {
                MessageBox.Show(string.Format("Unable to convert '{0}' to a date and time.",
                                  dateValue));
            }
