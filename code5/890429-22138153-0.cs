    DataAdapter.UpdateCommand = new OleDbCommandBuilder(DataAdapter).GetUpdateCommand();
    DataAdapter.Update(TeachersDataTable);
    
    string selectQuery = "SELECT * FROM Students";
    DataAdapter.UpdateCommand = new OleDbCommandBuilder(DataAdapter).GetUpdateCommand();
    DataAdapter.Update(StudentsDataTable); 
