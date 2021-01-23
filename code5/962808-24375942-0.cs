    Ticket ticket;
    string employeeName;
    using (var db = new MyContext())
    {
      // assume 1 exists
      ticket = db.Tickets.Where(t => t.id = 1).First();
      // this is possible (see below why it may not be)
      employeeName = person.ResponsibleEmployee.Name;
    }
    // this is never possible, the context does not exist
    employeeName = person.ResponsibleEmployee.Name;
