    for (int j = 1; j <= days - 1; j++)
    {
        ...
        chk = new CheckBox();
        chk.ID = j.ToString();
        chk.AutoPostBack = true;
        // chk.Checked = true;
        
        lbl = new Label();
        lbl.Text = startDate.ToString("dd/MM/yyyy");
        lbl.ID = j.ToString();
        PlaceHolder1.Controls.Add(lbl);
        PlaceHolder1.Controls.Add(chk);
        PlaceHolder1.Controls.Add(new RadioButton { });
        PlaceHolder1.Controls.Add(new LiteralControl("<BR>"));
        startDate = startDate.AddDays(1);
        //No need fot this. You still have the object chk from a few lines above
        // CheckBox cb = (CheckBox)Page.FindControl("chk" + j);
        //If you want to use this, put these lines before you add the control.
        //chk.Checked = CheckBox1Checked;
        //chk.oncheckedchanged += CheckBox1OnChecked;
        //You should declare this outside the for-loop or even outside the method 
        //if you want to use it elsewhere
        int chkcount = 0;
        //Here you are using the correct object.
        //chk.Checked should reflect exactly what you've set above.
         if (chk.Checked)
        {
            chkcount++;
        }
        int chkcount1 = chkcount;
    }
