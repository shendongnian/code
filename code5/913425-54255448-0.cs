       //set the list of dateColumns which will be used to formate them
                List<int> dateColumns = new List<int>();
                //get the first indexer
                int datecolumn = 1;
                //loop through the object and get the list of datecolumns
                foreach (var PropertyInfo in data.FirstOrDefault().GetType().GetProperties())
                {
                    //check if property is of DateTime type or nullable DateTime type
                    if (PropertyInfo.PropertyType == typeof(DateTime) || PropertyInfo.PropertyType == typeof(DateTime?))
                    {
                        dateColumns.Add(datecolumn);
                    }
                    datecolumn++;
                }
   
                // Create the file using the FileInfo object
                var file = new FileInfo(outputDir + fileName);
                //create new excel package and save it
                using (var package = new ExcelPackage())
                {
                    //create new worksheet
                    var worksheet = package.Workbook.Worksheets.Add("Results");
                
                    // add headers
                    worksheet.Cells["A1"].LoadFromCollection(data, true);
                    //format date field 
                    dateColumns.ForEach(item => worksheet.Column(item).Style.Numberformat.Format = "dd-mm-yyyy");
                    // auto size columns
                    worksheet.Cells.AutoFitColumns();
                 
                    //save package
                    package.SaveAs(file);
                }
