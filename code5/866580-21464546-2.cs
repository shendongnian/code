    db.Invoices.Where(i => i.IsPaid)
    .Where(i => i.Invoices_Parts.Any(ip => !ip.IsClaimed && 
        ip.Part.IsActive && 
        ip.OrganisationID == loggedInUser.OrganisationID)
    .Select(i => i.InvoiceId)
    .ToList();
