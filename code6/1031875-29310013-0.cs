    public void textB_TextChanged(object sender, EventArgs e)
    {
         MyTextbox.Text = ToTitleCase(MyTextbox.Text);
    }
    
    public static string ToTitleCase(string stringToConvert)
    {
      return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(stringToConvert);
    }
