        protected void txt_Start_TextChanged(object sender, EventArgs e)
        {
            DateTime start = new DateTime();
            //using System.Globalization;
            if (DateTime.TryParseExact(txt_Start.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
            {
                DateTime end = start.AddYears(1).AddDays(-1);
                txt_End.Text = end.ToString("dd/MM/yyyy");
                lbl_wrongdate.Text = "";
            }
            else
            {
                lbl_wrongdate.Text = "Wrong date format. Allowed formats is dd/mm/yyyy";
                txt_End.Text = "";
            }
        }
