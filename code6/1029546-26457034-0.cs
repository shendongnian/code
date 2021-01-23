        /// <summary>
        /// The procedure examines the workbook that you specify, 
        /// looking for the part that contains defined names. 
        /// If it exists, the procedure iterates through all the 
        /// contents of the part, adding the name and value for 
        /// each defined name to the returned dictionary
        /// </summary>
        public static IDictionary<String, String> XLGetDefinedNames(String fileName)
        {
          var returnValue = new Dictionary<String, String>();
          //
          using (SpreadsheetDocument document = 
              SpreadsheetDocument.Open(fileName, false))
          {
            var wbPart = document.WorkbookPart;
            //
            DefinedNames definedNames = wbPart.Workbook.DefinedNames;
            if (definedNames != null)
            {
              foreach (DefinedName dn in definedNames)
                returnValue.Add(dn.Name.Value, dn.Text);
            }
          }
          //
          return returnValue;
        }
