    public List<SelectListItem> PopulateList()
    {
        var yearsAtAddressList = new List<SelectListItem>();
        yearsAtAddressList.Add(new SelectListItem { Text = "Please select...", Value = "Please select..." });
        yearsAtAddressList.Add(new SelectListItem { Text = Less than 1 year", Value = "0" });
        for (int i = 0; i < 15; i++)
        {
            yearsAtAddressList.Add(new SelectListItem { Text = i, Value = i });
        }
        return yearsAtAddressList;
    }
