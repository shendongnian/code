    // the context class
    AccountingModelContext db = new AccountingModelContext();
    // query some data
    List<Reconciliation> recon = db.Reconciliations
            .Where(r => r.ReconNum == 112293)  // scenario 18 
            .Include(r => r.ReconciliationDetails.Select(rd => rd.JrnlEntryDetail).Select(jd => jd.JrnlEntry).Select(j => j.ARInvoices.Select(i => i.ARInvoiceDetails)))
            .Include(r => r.ReconciliationDetails.Select(rd => rd.JrnlEntryDetail).Select(jd => jd.JrnlEntry).Select(j => j.ARCredMemoes.Select(c => c.ARCredMemoDetails)))
            .ToList();
    // class that will manager business logic and generate facts with above data
    ReconFactGenerator generator = new ReconFactGenerator(recon);
    // call to the method that will return a list of facts
    List<ReconFact> scenario18 = generator.GenerateFacts();
    // ERROR RAISED HERE
    // scenario18.ForEach(f => db.ReconFacts.Add(f));
    // INSTEAD OF REUSING THE CONTEXT I CREATE A NEW ONE PROBLEM SOLVED !
    using (db = new AccountingModelContext())
    {
      scenario18.ForEach(f => db.ReconFacts.Add(f));
      db.SaveChanges();
    }
    db.SaveChanges();
