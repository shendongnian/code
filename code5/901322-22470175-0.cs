     var resultSet = (xmlDoc.Root.Descendants("Row").Select(result => new
            {
                MonthYearShortName = (DateTime)result.Element(ns + "Column0"),
                Product = (String)result.Element("Column1"),
                Actual = (decimal)result.Element("Column2"),
                Forecast = (decimal)result.Element("Column3"),
                Target = (decimal)result.Element("Column4"),
            }));
     var json = JsonConvert.SerializeObject(resultSet);
     Console.WriteLine(json);
