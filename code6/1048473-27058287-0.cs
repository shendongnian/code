    // Get employee from Session
    Employee employee = (Employee)Session["Employee"];
    
    // Check if employee exists
    if(employee != null)
    {
        RenderMenu(employee);
    }
    
    // Method to render list
    private void RenderMenu(Employee employee)
    {
        StringBuilder _menu = new StringBuilder();
        _menu.Append("<ul>");
    
        // Property boolean that indicates if the employee is an admin
        if(employee.IsAdmin)
        {
            //Add items for admin
        } 
    
        _menu.Append("</ul>");
    
        // Panel on the aspx page where you add the menu control
        this.pnlMenu.Controls.Add(new LiteralControl() { Text = _menu.ToString() });
    }
