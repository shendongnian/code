    if(_Row!=null)
    {
        string str = _Row.Cells[0].Text; -->it shows the error her.
        ViewState["DepartmentID"] = str;
    
        IList<MCX.ISupplierPortal.Database.dptDEPARTMENT> _EditDepartment =_decDepartment.GetDepartment(int.Parse(str));
    
        if (_EditDepartment != null)
        {
            foreach (MCX.ISupplierPortal.Database.dptDEPARTMENT _DepartmentList in _EditDepartment)
            {
                txtDepartmentName.Text = _DepartmentList.DepartmentName;
                txtDescription.Text = _DepartmentList.DepartmentDesc;
                ViewState["DepartmentID"] = _DepartmentList.DepartmentID.ToString();
    
            }                   
        }
        ViewState["PageMode"] = "Update";
    }
