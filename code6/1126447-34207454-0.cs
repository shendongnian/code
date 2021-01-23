    //This checks whether there's a record with same specific data.
    var kayitVarMi = _db.Sorgu.FirstOrDefault(a => a.Serial == sorgu.Serial);
                    if (kayitVarMi != null) // If there's
                    {
                        sorgu.Id = kayitVarMi.Id; //This one does the trick
                        _db.Entry(kayitVarMi).CurrentValues.SetValues(sorgu);
                    }
                    else // If not
                    {
                        _db.Sorgu.Add(sorgu);
                    }
                    // This whole block is in a transaction scope so I just check recordability.
                    if (_db.SaveChanges() > 0)
                    {
                        _sorguKaydedildiMi = true;
                    }
