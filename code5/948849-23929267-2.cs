    DataTable dt = new DataTable();
    dt.Columns.Add("loan_code", typeof(int));
    dt.Columns.Add("emp_num", typeof(int));
    dt.Columns.Add("Tot", typeof(int));
    foreach(var data in groupedData)
        dt.Rows.Add(data.LoanCode, data.EmpNum, data.Tot);
