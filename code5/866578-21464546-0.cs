    from invoice in db.Invoices
    where invoice.IsPaid
    where invoice.Invoices_Parts.Any(ip => !ip.IsClaimed && 
        ip.Part.IsActive && 
        ip.OrganisationID == loggedInUser.OrganisationID)
    select invoice.InvoiceId
