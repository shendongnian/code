    public class IdentifiedDupemployees {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string DateOfBirth { get; set; }
                public string address1 { get; set; }
                public int count {get; set;}
    }
    
    Public class employee 
    {
               public string Ids {get; set;}
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string DateOfBirth { get; set; }
                public string address1 { get; set; }
    }
    
    
    namespace DuplicatePatient.Storage.Indexes
    {
        class DupFindPatientId: AbstractMultiMapIndexCreationTask<DupFindPatientId.Result>
        {
    
            public class Result
            {
    
                public string Ids { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string DateOfBirth { get; set; }
    
                public string address1 { get; set; }
            }
            public DupFindPatientId()
            {
    
                AddMap<IdentifiedDupPatients>(entities => from a in entities
    
                                                          select new
                                                          {
                                                              Ids = (string)null,
                                                              FirstName = a.FirstName,
                                                              LastName = a.LastName,
                                                              DateOfBirth = a.DOB,
                                                              address1 = a.address1,
                                                              Duplicate = true
                                                          });
    
                AddMap<Patient>(entities => from b in entities
                                            //from c in b.FirstName
                                            select new
                                            {
                                                Ids = b.Id,
                                                FirstName = b.FirstName,
                                                LastName = b.LastName,
                                                DateOfBirth = b.DateOfBirth,
                                                address1 = b.Address1,
                                                Duplicate = false
                                            });
    
                Reduce = results => from result in results
                                    group result by new
                                    {
                                        result.FirstName,
                                        result.LastName,
                                        result.DateOfBirth,
                                        result.address1
    
                                       }
                                        into g   
    
                                        select new
                                        {
                                            Ids = g.Select(x => x.Ids).Where(x => x != null).First(),
                                            FirstName = g.Key.FirstName,
                                            LastName = g.Key.LastName,
                                            DateOfBirth = g.Key.DateOfBirth,
                                            address1 = g.Key.address1,
                                            Duplicate = g.Any(x=>Duplicate)
                                        };
            }
