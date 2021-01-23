    const string reportNamespace = "MyNamespace.Reports";
    
    ReportParams parameters = new ReportParams(param1, param2, param3); 
    Type rType = Type.GetType(reportNamespace + "." + type);
    
    if (rType != null)
    {
        object report = Activator.CreateInstance(rType, parameters);
        // use the report
    }
