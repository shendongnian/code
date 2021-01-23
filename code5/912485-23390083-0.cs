    scarRevision = db.ScarRevisions
    .Include(s => s.Author)
    .Include(s => s.Scar.Author)
    .Include(s => s.Scar.LockedBy)
    .Include(s => s.Scar.Part)
    .Include(s => s.Scar.Supplier)
    .Include(s => s.ScarGeneralSection.GeneralSectionAttachments)
    .Include(s => s.ScarGeneralSection.SupplierContacts.Select(sc => sc.Contact))
    // on and on and on...
    .FirstOrDefault(s => s.Scar.ScarNumber == scarNumber && s.RevisionNumber == revisionNumber);
