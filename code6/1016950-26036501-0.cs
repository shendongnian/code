     private void button1_Click(object sender, EventArgs e)
        {
            ReadAndFileter();
        }
        private void ReadAndFileter()
        {
            try
            {
                using(System.IO.StreamReader reader = new System.IO.StreamReader("file.txt"))
                {
                    string line;
                    string []array;
                    int rowcount= 0;
                    decimal number;
                    string[] separators = { "\t", " " };
                    int columnCount = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                       
                       array = line.Split(separators, StringSplitOptions.RemoveEmptyEntries); 
                       dataGridView1.Rows.Add();
                       foreach  (string str in array)
                       {
                          
                           if (Decimal.TryParse(str,out number))
                           {
                               dataGridView1.Rows[rowcount].Cells[columnCount++].Value = number;                               
                           }                           
                       }
                       rowcount++;
                       columnCount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
