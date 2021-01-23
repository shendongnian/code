    using System.Globalization;
    private void Convert_From_Hijri_To_Gregorian(System.Object sender, System.EventArgs e)
    {
    	CultureInfo arCI = new CultureInfo("ar-SA");
    	string hijri = TextBox1.Text;
    
    	DateTime tempDate = DateTime.ParseExact(hijri, "dd/MM/yyyy", arCI.DateTimeFormat, DateTimeStyles.AllowInnerWhite);
        TextBox2.Text = tempDate.ToString("dd/MM/yyyy");
    
    
    }
