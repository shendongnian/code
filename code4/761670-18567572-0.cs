    private bool ValidateInput()
    {
        bool ret = true;
    
        // List all the inputs you want, add a description for each one
        List<KeyValuePair<<string,string>) inputs = new Dictionary<string,string>();
        
        inputs.Add(new KeyValuePair<string,string>(tbVendorName.Text, "Vendor Name"));
        inputs.Add(new KeyValuePair<string,string>(tbVendorAddress.Text, "Vendor Address"));
        // .. and so on and so forth
    
        // Build a list of the empty ones 
        if(inputs.Any(i => string.IsNullOrEmpty(i.Key))
        {
            var msg = string.Join(", ", inputs.Where(i => string.IsNullOrEmpty(i.Key));
            MessageBox.Show(string.Format("The following inputs are required: {0}", msg);
            ret = false;
        }
    
        return ret;
    }
