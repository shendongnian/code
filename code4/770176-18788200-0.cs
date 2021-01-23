            Dictionary<string, Worksheet> dict = new Dictionary<string, Worksheet>();
            foreach ( Worksheet worksheet in excelWorkbook.Worksheets )
            {
               dict.Add( worksheet.Name, worksheet );
            }
            // accessing the desired worksheet in the dictionary
            MessageBox.Show( dict[ "Sheet1" ].Name );
