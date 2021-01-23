            DateTime dt;
            if (DateTime.TryParseExact(txtDate.Text,"dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out dt))
            {
                string s= dt.ToString("dd-MMM-yyyy");
            }
            else
            {
               //error message invalid date
            }
