    public class Company
    {
        ...
        public  virtual void AddClientToCompany(Client client)
        {
            clients.Add(client);
            // essential line
            client.Company = this;
        }
        ...
