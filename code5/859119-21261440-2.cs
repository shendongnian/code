            var doc = XDocument.Load("XMLFile1.xml");
            XNamespace ns = @"http://www.ibm.com/software/analytics/spss/xml/oms";
              
            var pivotTables = doc.Descendants(ns + "pivotTable");
            // identify the pivottable by the text "Classified Function Coefficients"
            var theTable = pivotTables.Where(table => table.Attribute( "text").Value == "Classification Function Coefficients");
            // first dimension
            var dimension = theTable.Elements(ns + "dimension").First();
            // first dimensions categories
            var categories = dimension.Elements(ns + "category");
            foreach (var category in categories)
            {
                // at index 5 there exists a category without varname and text="(Constant)"
                // skip it
                if(!category.Attributes().Any(attr => attr.Name == "varName"))
                    continue;
                // here's the varname                
                var varName = category.Attribute( "varName").Value;
                if (varName.StartsWith("("))
                    continue;
                System.Diagnostics.Debug.WriteLine(varName);
                var cells = category.Descendants(ns + "cell");
                foreach (var cell in cells)
                {
                    // here's the number of the cell
                    var number = cell.Attribute("number").Value;
                    System.Diagnostics.Debug.WriteLine(number);
                }
            }
