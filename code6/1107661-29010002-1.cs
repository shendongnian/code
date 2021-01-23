    string value = ReadCell.ReadCellValue(allEmployeeTimesheet[i], "Sheet1", "A1");
    if (string.IsNullOrWhiteSpace(value))
    {
        // Handle the null/empty string here.
        // From what you said probably the logic you wanted to use in your second catch block.
    }
