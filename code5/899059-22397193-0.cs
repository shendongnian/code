    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem repeated in rptInterestCategory.Items)
        {
            var rptInterests = (Repeater)FindControlRecursive(repeated, "rptInterests");
            foreach (RepeaterItem repeatedInterest in rptInterests.Items)
            {
                var cbInterest = (CheckBox)FindControlRecursive(repeatedInterest , "cbInterest");
                if (cbInterest.Checked)
                {
                    name = cbInterest.Text;
                }
            }
        }
}
