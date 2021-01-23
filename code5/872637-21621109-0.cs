    private void grdOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0)
                {
                    //Column0 will be that column on which you will click
                    //Suppose column having string values 
                    string Column1 = grdOne["Column1", e.RowIndex].Value.ToString();
                    string Column2  = grdOne["Column2", e.RowIndex].Value.ToString();
                    string Column3  = grdOne["Column3", e.RowIndex].Value.ToString();
                    //here you got all these values 
                }
            }
