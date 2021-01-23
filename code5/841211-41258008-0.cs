    worksheet.Protection.IsProtected = true;
    //I'm creating a template for users to fill in data.These headers
    //will come from database tables later on.
    //So tableHeaders is an array of strings
    for (int i = 1; i <= tableHeaders.Length; i++)
                {
                    worksheet.Column(i).Style.Locked = false;
                }
    //And then lock the first row.
    worksheet.Row(1).Style.Locked = true;
    //Additionally don't allow user to change sheet names
    excelPackage.Workbook.Protection.LockStructure = true;
