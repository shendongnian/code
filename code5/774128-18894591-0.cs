    if(!db.Suburbs.where(x=>x.SuburbName.Equel(addrSuburb.SuburbName)).ToList().Count > 0)
    {
    // Insert Flow
     
    db.Postcodes.Attach(addrPostCode);
    db.Suburbs.Attach(addrSuburb);
    db.States.Attach(addrState);
    db.Addresses.Attach(addrCust);
    
    db.Postcodes.Add(addrPostCode);
    db.Suburbs.Add(addrSuburb);
    db.States.Add(addrState);                        
    db.Addresses.Add(addrCust);
    
    }
    else
    {
      // Update Flow
      
    db.Postcodes.Attach(addrPostCode);
    db.Suburbs.Attach(addrSuburb);
    db.States.Attach(addrState);
    db.Addresses.Attach(addrCust);
    
    db.Entry(addrPostCode).State = EntityState.Modified;
    db.Entry(addrSuburb).State = EntityState.Modified;
    db.Entry(addrState).State = EntityState.Modified;
    db.Entry(addrCust).State = EntityState.Modified;
    
    }
    
    db.SaveChanges();
