            var doc = XDocument.Load("path/to/yourfile.xml");
            var pivotTables = doc.Descendants("pivotTable");
            // identify the pivottable by the text "Classified Function Coefficients"
            var theTable = pivotTables.Where(table => table.Attribute("text").Value == "Classified Function Coefficients");
            // first dimension
            var dimension = theTable.Elements("dimension").First();
            // first dimensions categories
            var categories = dimension.Elements("category");
            foreach (var category in categories)
            {
                // here's the varname
                var varName = category.Attribute("varName").Value;
                var cells = category.Descendants("cell");
                foreach (var cell in cells)
                {
                    // here's the number of the cell
                    var number = cell.Attribute("number").Value;
                }
            }
