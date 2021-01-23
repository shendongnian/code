    var names = (from witness in this.Context.witness
                    select witness.Person.FirstName).ToArray();
    var allNames = string.Join(", ", names);
    IQueryable<WitnessInfo> witnessQuery = from witness in this.Context.witness
                                           where witness.DAFile.Id == id
                                           select new WitnessInfo
                                           {
                                               WCFId = Guid.NewGuid(),
                                               witnessName = witness.Person.FirstName,
                                               AllNames = allNames
                                           };
