    for (int i = 0; i < 2; i++)
    {
        Button b = new Button();
        b.ID = i.ToString();
        b.Text = i.ToString();
        b.Width=250;
        b.Height = 100;
        b.Style.Add("background-color", "red");
        Page.Form.Controls.Add(b);
    }
