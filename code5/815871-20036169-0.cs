    void dataGridViewShowCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Problem is in this line, re-assigning the same event handler again to the same event
            // event handler will execute more than 1 time and number of execution will also keep increasing each time
            dataGridViewShowCourse.CellContentClick += new DataGridViewCellEventHandler(dataGridViewShowCourse_CellContentClick);
            //make sure click not on header and column is type of ButtonColumn
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
            {
                 //TODO - Execute Code Here
                MessageBox.Show("I pressed CellButton");
            }
        }
