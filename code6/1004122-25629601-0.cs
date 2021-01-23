      OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Tab delimited file (*.txt)|*.txt";
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var reader = new Microsoft.VisualBasic.FileIO.TextFieldParser(od.FileName))
                {
                    reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                    reader.Delimiters = new string[] { "\t" }; // the delimeter of the lines in your file
                    reader.ReadLine(); // skip header if needed, ignore titles
                    while (!reader.EndOfData)
                    {
                        try
                        {
                            var currentRow = reader.ReadFields(); // string array
                           // Include code here to handle the row.
                        catch (Microsoft.VisualBasic.FileIO.MalformedLineException vex)
                        {
                            MessageBox.Show("Line " + vex.Message + " is invalid. Skipping");
                        }
                   }
             }
          } 
