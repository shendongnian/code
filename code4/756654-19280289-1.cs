    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in questionRepeater.Items)
        {
            TextBox Qbox = item.FindControl("txtQ") as TextBox;
            TextBox Ansbox = item.FindControl("txtAns") as TextBox;
            string Question = Qbox.Text;
            string Answer =  Ansbox.Text;
            if (!string.IsNullOrEmpty(Answer))
            {
                //Perform your insert operation.
            }
        }
    }
