    // Clear items:    
    DropDownList1.Items.Clear();
    // Add default item to the list
    DropDownList1.Items.Add("--Year--");
    // Start loop
    for (int i = 0; i < 2; i++)
    {
        // For each pass add an item
        // Add a number of years (negative, which will subtract) to current year
        DropDownList1.Items.Add(DateTime.Now.AddYears(-i).Year.ToString());
    }
