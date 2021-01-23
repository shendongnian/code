    DataAdapter.UpdateCommand = new OleDbCommandBuilder(DataAdapter).GetUpdateCommand();
    DataAdapter.Update(TeachersDataTable);
    
    DataAdapter.SelectCommand.CommandText = "SELECT * FROM Students";
    DataAdapter.UpdateCommand = new OleDbCommandBuilder(DataAdapter).GetUpdateCommand();
    DataAdapter.Update(StudentsDataTable); 
