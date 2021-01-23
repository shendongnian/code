    //test to see if the DataGridView has any rows
    if (gridIn.RowCount > 0)
    {
        string value = "";
        DataGridViewRow dr = new DataGridViewRow();
        StreamWriter swOut = new StreamWriter(outputFile);
    
        //write header rows to csv
        for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
        {
            if (i > 0)
            {
                swOut.Write(",");
            }
            swOut.Write(gridIn.Columns[i].HeaderText);
        }
    
        swOut.WriteLine();
    
        //write DataGridView rows to csv
        bool previousSkipped = false;
        for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
        {
            if (j > 0 && !previousSkipped)
            {
                swOut.WriteLine();
            }
    
            dr = gridIn.Rows[j];
    
            for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
            {
                if (dr.Cells[2].Value.ToString().ToLower().Contains(Selected_Combo.ToLower()))
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    value = dr.Cells[i].Value.ToString();
                    //replace comma's with spaces
                    value = value.Replace(',', ' ');
                    //replace embedded newlines with spaces
                    value = value.Replace(Environment.NewLine, " ");
    
                    swOut.Write(value);
                    previousSkipped = false;
                }
                else
                {
                    previousSkipped = true; //To avoid using previousSkipped = false; more than required
                }
            }
        }
        swOut.Close();
    }
