            var csvData = File.ReadAllLines("d:\\test.csv");
            var dataRows = csvData.Skip(1).ToList();
            var csvHeaderColumns = csvData.First().Split(',').ToList();
           
            var outputList = new List<MappingData>();
            
            foreach (var columnName in csvHeaderColumns)
            {
                var obj = new MappingData { columnName = columnName, data = new List<string>() };
                foreach (var rowStrings in dataRows.Select(dataRow => dataRow.Split(',').ToList()))
                {
                    obj.data.Add(rowStrings[csvHeaderColumns.IndexOf(columnName)]);
                }
                
                outputList.Add(obj);
            }
