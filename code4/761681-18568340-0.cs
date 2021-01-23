    private void btnOK_Click(object sender, EventArgs e)
    {
        var errors = Validate();
        if (errors.Any())
        {
            var sb = new StringBuilder();
            sb.AppendLine("The following errors were found:");
            foreach (string s in errors)
            {
                sb.AppendLine(s);
            }
            MessageBox.Show(sb.ToString());
            return;
        }
    }
    private IEnumerable<string> Validate()
    {
        if (String.IsNullOrEmpty(tbVendorName.Text))
        {
            yield return "Vendor name missing";
        }
        if (!string.IsNullOrEmpty(rtbVendorAddress.Text))
        {
            yield return "Vendor address missing";
        }
        if (!string.IsNullOrEmpty(tbVendorEmail.Text))
        {
            yield return "Vendor email missing";
        }
    }
