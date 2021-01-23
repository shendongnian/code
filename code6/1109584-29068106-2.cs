            // Populate your employeeList
            TextWriter textWriter = new StreamWriter("foo.csv"); //foo.csv is the file you are saving to
            var csv = new CsvWriter(textWriter);
            foreach (var employee in employeeList)
            {
                csv.WriteField(employee.Id);
                csv.WriteField(employee.Date.ToShortDateString());
                csv.WriteField(employee.Account.AccountName);
                csv.WriteField(employee.LabourChargeType.LabourChargeTypeName);
                csv.NextRecord();
            }
            textWriter.Flush();
            textWriter.Close();
            textWriter = null;
