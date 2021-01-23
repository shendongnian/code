    protected void Button3_Click(object sender, EventArgs e)
        {
            createControls();
        }
    private void createControls()
        {
            PlaceHolder2.Controls.Clear();
            for (int i = 0; i < 4; i++)
            {
                TextBox tb = new TextBox();
                tb.ID = "TextBox" + i;
                tb.Text = tb.ID;
                LiteralControl linebreak = new LiteralControl("<br />");
                PlaceHolder2.Controls.Add(tb);
                PlaceHolder2.Controls.Add(linebreak);
            }
        }
