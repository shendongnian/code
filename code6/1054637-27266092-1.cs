    public bool AutoComplete()
    {
        try
        { 
            DataTable dtEmpName=/////// store the employees name in this DataTable.
            var empNames = dtEmpName.Select(s => s.EmpName('the column you want').Distinct().ToArray();
            /////// Auto complete Name from Surname
            AutoCompleteStringCollection instcol = new AutoCompleteStringCollection();
            instcol.AddRange(empNames);
            txtEmpNames.AutoCompleteCustomSource = instcol;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
