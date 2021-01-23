                for (int i = 0; i < 13; i++)
                 {
                DataGridViewTextBoxCell txtbx = new DataGridViewTextBoxCell();
                DataGridViewColumn txcol = new DataGridViewColumn();
                txcol.CellTemplate = txtbx;
                txcol.HeaderText = "column" + i.ToString();
                dg1.Columns.Add(txcol);
               
                }
            dg1.Rows.Add(8);
            int dgRw, dgCol;
            dgRw = dgCol = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dg1[dgCol, dgRw].Value = dr[0].ToString();       
             
                dgRw++;
                if (dgRw == 8)
                {
                    dgCol++;            
                    dgRw = 0;
                }
