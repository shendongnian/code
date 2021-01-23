    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        string text = tb.Text;
        try
        {
            Decimal dec = Decimal.Parse(text);
            TextValid = true;
        }
        catch (System.FormatException ex)
        {
            Debug.WriteLine("Exception converting {1} to Decimal {0}", ex,text);
            TextValid = false;
        }
    }
