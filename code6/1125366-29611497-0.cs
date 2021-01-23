      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex+"   "+e.ColumnIndex);
         //   Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
           // Int32 selectedColumnCount = dataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Selected);
            if ( e.ColumnIndex == 0  && e.RowIndex >= 0  )
            {
                string x=dataGridView1.Rows[e.RowIndex-1].Cells[6].Value.ToString();
                if ((bool)dataGridView1.Rows[e.RowIndex-1].Cells[0].Value == false && x!=null )
                {
                    if(x==Util.User.Display_Name)
                    {
                        Tasks tsk = taskController.taskController.Read(dataGridView1.Rows[e.RowIndex-1].Cells[1].Value + "");
                        tsk.Done_By = "";
                        tsk.Status = "";
                        taskController.taskController.Update(tsk);
                        dataGridView1.Rows[0].Cells[1].Value = true;
                    }
                }
                else
                {
                    if ((bool)dataGridView1.Rows[e.RowIndex-1].Cells[0].Value == true)
                    {
                        Tasks tsk = taskController.taskController.Read(dataGridView1.Rows[e.RowIndex-1].Cells[1].Value + "");
                        tsk.Done_By = utility.Util.User.Display_Name;
                        tsk.Status = "Closed";
                        taskController.taskController.Update(tsk);
                    }
                }
            
            }
        }
