        var newCustomerFrm = new CustomerForm();
        var existingCustomerFrmReadOnly = new CustomerForm(BLL.GetCustomerById("123"))
        {
            EnableEdit = false
        };
        var existingCustomerFrmToEdit = new CustomerForm(BLL.GetCustomerById("123"))
        {
            EnableEdit = true
        };
