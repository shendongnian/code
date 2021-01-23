    try
    {
       txtStudentName.AutoCompleteCustomSource = new AutoCompleteStringCollection();                  
       for(int i=0;i<dgvStudentDetail.RowCount;i++){
        txtStudentName.AutoCompleteCustomSource.Add(dgvStudentDetail.Rows[i].Cells["StudentName"].Value.ToString());
       }
       txtStudentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
       txtStudentName.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message);
    }
