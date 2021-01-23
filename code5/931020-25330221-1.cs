    var dsTasks = new Tasks().Find(sqlParameters);
    var dsValidators = new Validators().Find(sqlParameters);
    var dsProperties = new ValidatorProperties().Find(sqlParameters);
        			
    dsTasks.Tables[0].TableName = "Tasks";
    dsValidators.Tables[0].TableName = "Validators";
    dsProperties.Tables[0].TableName = "ValidatorProperties";
        
    var ds = new DataSet {DataSetName = "ValidatorsByTask"};
    ds.Tables.Add(dsTasks.Tables[0].Copy());
    ds.Tables.Add(dsValidators.Tables[0].Copy());
    ds.Tables.Add(dsProperties.Tables[0].Copy());
        
    ds.Relations.Add("Task_Validators", ds.Tables["Tasks"].Columns["Id"], ds.Tables["Validators"].Columns["TaskId"]);
    ds.Relations.Add("Validator_Properties", ds.Tables["Validators"].Columns["Id"], ds.Tables["ValidatorProperties"].Columns["ValidatorId"]);
        			
    var data = ConvertDataSetWithRelationsToCamelCaseObject(ds);
