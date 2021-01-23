    string[] txtArr = { "SupperTxtBox", "YogurtTxtBox", "DessertTxtBox" };
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] lblArr = { "Best Supper Club", "Best Place for Frozen Yogurt", "Best Place for Dessert" };
        for (int i = 0; i < lblArr.Length; i++)
        {
            Label lbl = new Label();
            lbl.Text = "<br>" + lblArr[i] + "<br>";
            TextBox txt = new TextBox();
            txt.ID = txtArr[i];
            Form.Controls.Add(lbl);
            Form.Controls.Add(txt);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int Count = 0;
        foreach (string item in txtArr)
        {
            TextBox t = (TextBox)Form.FindControl(item);
            if (t != null)
            {
                if (t.Text.Trim() != "")
                    Count++;
            }
        }
        if (Count < 3)
        {
            Response.Write("<br>You fill " + Count + " textbox, Please fill 3 textbox!");
        }
    }
