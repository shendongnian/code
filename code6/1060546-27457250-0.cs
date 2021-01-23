    public void TextBoxGenerator(int num)
    {
        TextBox txt;
        for (int i = 0; i < num; i++)
        {
            txt = new TextBox();
            txt.Text = (i+1).ToString();
            stackpanel1.Children.Add(txt);
        }
    }
