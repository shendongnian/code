    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int percent;
        int selectedPercentage = int.Parse(ddlchoise.SelectedItem.Text);
        var allowed = ddlchoise.Items.Cast<ListItem>()
           .Select(li => li.Text)
           .Where(t => int.TryParse(t, out percent) && percent >= selectedPercentage);
        args.IsValid = allowed.Contains(txtpercents.Text.Trim());
    }
