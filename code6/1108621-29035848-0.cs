    var query =
        from contact in contacts
        from order in orders
        where contact.ContactID == order.Contact.ContactID
            && order.TotalDue < totalDue
        select new
        {
            ContactID = contact.ContactID,
            LastName = contact.LastName,
            FirstName = contact.FirstName,
            OrderID = order.SalesOrderID,
            Total = order.TotalDue
        };
    foreach (var smallOrder in query)
    {
        Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
            smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
            smallOrder.OrderID, smallOrder.Total);
    }
}
