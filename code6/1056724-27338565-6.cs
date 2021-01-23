    protected void editCustomerTicket()
    {
        GridViewTicketHistory.AutoGenerateEditButton = true;
        var a = (from employee in entities.Employees
                from ticket in employee.EmployeeTicket
                select new TicketHistory 
                {
                    ID = employee.ID,
                    Name = employee.Name,
                    TicketNo = ticket.TicketNo,
                    Subject = ticket.Subject,
                    Date = ticket.Date,
                    StateID = ticket.StateID,
                    StateName = ticket.State.StateName
                }).ToList();
        GridViewTicketHistory.DataSource = a;
        GridViewTicketHistory.DataBind();
    }
