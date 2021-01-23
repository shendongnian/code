    for(int i = 0; i < dt.Rows.Count; i++)
    {
        string buttonName = "Button" + i.ToString();
        Control[] buttons = this.Controls.Find(buttonName, false);
        if(buttons.Length == 1 && buttons[0] is Button)
        {
            Button btn = (Button) buttons[0];
            btn.Text = dt.Rows[i].Field<string>("DEPT_NAME");
        }
        else throw new Exception("Something went wrong!");
    }
