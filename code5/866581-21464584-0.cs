    IQueryable<int> partIds = db.Parts
      .Where(x => x.OrganisationID == loggedInUser.OrganisationID && x.IsActive)
      .Select(y => y.PartID);
        
    List<string> invoiceIds = db.Invoices_Parts
       .Where(x =>  !x.IsClaimed && x.Invoice.IsPaid && partIds.Contains(x.PartID))
       .Select(y => y.InvoiceID.ToString())
       .Distinct()
       .ToList();
