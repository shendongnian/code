    List<ReportParameter> paramList = new List<ReportParameter>();
    ReportParameter param = new ReportParameter("ParamName");
    
    // Create the string array of values to pass
    
    string[] values = new string[]{"x", "y", "z"};
    
    // Add a range of elements from an array to the end of the StringCollection.
    
    param.Values.AddRange(GetStringArray());
    
    // Add the parameter to the list of ReportParameters
    
    paramList.Add(param);
    
    // Set the reports parameters
    
    this.ReportViewer1.ServerReport.SetParameters(paramList);
