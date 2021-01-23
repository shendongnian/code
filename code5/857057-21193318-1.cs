    string DataSetName = "DataSet1Parameter";
    string SelectedMethod = "GetSomeEmployees";
    string Parameter = "ID";
        
    ObjectDataSource objDataSource = new ObjectDataSource() { ID = DataSetName, TypeName = "BussinessLogic.Custom", SelectMethod = SelectedMethod};
        objDataSource.SelectParameters.Add(new Parameter("id"));
