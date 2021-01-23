    IQueryable<WitnessInfo> witnessQuery = from witness in this.Context.witness
                                           where witness.DAFile.Id == id
                                           select new WitnessInfo
                                           {
                                               WCFId = Guid.NewGuid(),
                                               witnessName = witness.Person.FirstName,
                                           };
