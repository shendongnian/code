    foreach (var item in names)
            {
                List<Test> specificData = data.Where(d => d.FirstName == item.Key).ToList();
                DataRow newRow = tbl.NewRow();
                newRow["LastName"] = specificData[0].LastName;
                newRow["FirstName"] = item.Key;
                newRow["AnnualRate"] = specificData.Sum(s => s.AnnualRate);
                foreach (var val in fn)
                {
                    newRow[val.Key] = specificData.Where(s => s.FundNumber == val.Key).Sum(s => s.PercentSalary) + "%";
                }
                tbl.Rows.Add(newRow);
            }
