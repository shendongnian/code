            System.Globalization.DateTimeFormatInfo dtfi = null;
            DateTime dtProjectStartDate = new DateTime(2008, 4, 10); //year, month, day
            ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"); 
            dtfi = ci.DateTimeFormat;
            txtBox.Text = dtProjectStartDate.ToString("d", dtfi); // 10/4/2008
      
            System.Globalization.CultureInfo ciForSQL = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            System.Globalization.DateTimeFormatInfo dtfiForSQL = ciForSQL.DateTimeFormat;
            DateTime dtForSQL = Convert.ToDateTime(txtBox.Text, dtfiForSQL);
            txtBoxForSQL.Text = dtForSQL.ToString("d", dtfiForSQL); // 10/4/2008
