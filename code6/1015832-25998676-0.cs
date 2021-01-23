    private void button2_Click(object sender, EventArgs e)
        {
            //Contains the text of column0 e.g 001, 002 etc..
            List<string> myListCol0Text = new List<string>();
            //Contains the row index e.g 0, 1 ,2 ,3 etc...
            List<int> myListCol0Index = new List<int>();
            //Contains the strings of the resulting column0 datagrid
            List <string> col0 = new List<string>();
            //Contains the doubles of the resulting column2 datagrid
            List <double> col2 = new List<double>();
            int i = 0, j, k;
            
            foreach (DataGridViewRow row in InputDataGrid.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    break;
                }
                myListCol0Text.Add(row.Cells[0].Value.ToString ());
                myListCol0Index.Add(i);
                i++;
            }
            double dbl = 0;
            int count = 0;
            bool bl = false ;
            k = 0;
            while (myListCol0Text.Count != 0)
            {
                count = myListCol0Text.Count;
                k = 0;
                bl = false ;
                dbl = 0;
                for (j = 0; j < count - 1; j++)
                {
                    if (myListCol0Text[0] == myListCol0Text[k + 1])
                    {
                        if(!bl)
                        {
                            col0.Add(myListCol0Text[0].ToString());
                            dbl = Convert.ToDouble(dataGridView1.Rows[myListCol0Index[0]].Cells[2].Value);
                            dbl += Convert.ToDouble(dataGridView1.Rows[myListCol0Index[k + 1]].Cells[2].Value);
                            col2.Add(dbl);
                            bl = true;
                        }
                        else{
                            dbl += Convert.ToDouble(dataGridView1.Rows[myListCol0Index[k + 1]].Cells[2].Value);
                            col2[col2.Count -1] = dbl;
                        }
                        myListCol0Text.RemoveAt(k + 1);
                        myListCol0Index.RemoveAt(k + 1);
                    }
                    else
                    {
                        k++;
                    }
                }
                myListCol0Text.RemoveAt(0);
                myListCol0Index.RemoveAt(0);
            }
            DataGridViewRow row_;
            for (i = 0; i < col0.Count; i++)
            {
                row_ = new DataGridViewRow();
                row_.CreateCells(ResultDatagrid);
                row_.Cells[0].Value = col0[i];
                row_.Cells[1].Value = col2[i].ToString ();
                ResultDatagrid.Rows.Add(row_);
            }
        }
