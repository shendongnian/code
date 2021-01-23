     public string Text
            {
                get
                {
                    return DateTextBox.Text;
                }
                set
                {
                    try
                   {
                        DateTime d = DateTime.ParseExact(value, "yyyy/MM/dd",CultureInfo.InvarientCulture);
                        DateTextBox.Text = value;
                   }
                   catch
                   {
                        //// Code when it does not match format.
                    }
                }
        }
