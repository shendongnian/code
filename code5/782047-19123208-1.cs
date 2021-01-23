    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptPerson.Items)
        {
            CheckBox c = item.Controls[1] as CheckBox;
            if (c.Checked)
                doSomething((item.Controls[3] as HiddenField).Value);
        }
    }
