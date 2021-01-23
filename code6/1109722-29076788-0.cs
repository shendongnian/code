     protected void page_init(object sender, EventArgs e)
    {
        List<string> TempList = new List<string>();
        TempList.Add("Name1");
        TempList.Add("Name2");
        TempList.Add("Name3");
        TempList.Add("Name4");
        TempList.Add("Name5");
        TempList.Add("Name6");
        ViewState["numberOfReasons"] = TempList.Count;
        int i = 1;
        foreach (string row in TempList)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.ID = "reason_" + i.ToString();
            radioButton.GroupName = "reason";
            radioButton.Text = row;
            ViewState["reason_" + row] = row;
            this.Form.Controls.Add(radioButton);
            i++;
        }
    }
     protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (Control cntrl in this.Form.Controls.OfType<RadioButton>().Where(x => x.ID.Contains("reason")))
        {
            bool option = ((RadioButton)cntrl).Checked;
            if (option)
            {
                Label1.Text = cntrl.ID + " Checked";
            }
        }
    }
