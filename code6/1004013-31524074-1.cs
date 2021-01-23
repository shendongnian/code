    if (System.Globalization.CultureInfo.CurrentCulture.Calendar.ToString()   !="System.Globalization.GregorianCalendar")     
    {
    MessageBox.Show("Ivalid System Calender The Current Is "+ System.Globalization.CultureInfo.CurrentCulture.Calendar.ToString()+ Environment.NewLine + "Please Covert To GregorianCalendar");
    return;
    }
