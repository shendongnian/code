    Type typeExcel = Type.GetTypeFromProgID("Excel.Application");
    dynamic excel = Activator.CreateInstance(typeExcel);
    excel.Visible = true;
    dynamic workbooks = excel.Workbooks;
    workbooks.Add();
    workbooks.Add();
