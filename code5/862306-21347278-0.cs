            DateTime dt;
            if (DateTime.TryParse(txtDate.Text, System.Globalization.CultureInfo.InvariantCulture, out dt))
            {
                Session["TransDate"] = dt.ToString("dd-MMM-yyyy");
            }
            else
            {
               //error message invalid date
            }
