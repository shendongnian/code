    public class Contacts_GetCount: AbstractIndexCreationTask<ClientContactsModel, Contacts_GetCount.ContactResult>
    {
        public class ContactResult
        {
            public Guid ClientId { get; set; }
            public int Total { get; set; }
        }
        public Contacts_GetCount()
        {
            Map = contacts => from contact in contacts
                select new {
                    ClientId = contact.ClientId,
                    Total = contact.Contacts.Count
                };
            Reduce = results => from result in results
                group result by result.ClientId
                into g
                select new {
                    ClientId = g.Key,
                    Total = g.Sum(x=>x.Total)
                };
        }
    }
