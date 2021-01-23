    // Client class only cares about itself; is completely independent
    public class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public Client(string name, string surname, string dateOfBirth, string address)
        {
            FirstName = name;
            SecondName = surname;
            DateOfBirth = name;
            Address = address;
        }
    }
    // Client factory is responsible for creating clients
    class ClientFactory
    {
        // Event name should describe what happened
        public event EventHandler ClientCreated;
        public Client CreateNewClient(string name, string surname, string dateOfBirth, string address)
        {
            // no need to copy the arguments into new local variables again; arguments
            // are already local
            Client client = new Client(name, surname, dateOfBirth, address);
            // raise the ClientCreated event
            OnClientCreated();
            // return the created client
            return client;
        }
        // provide this proctected virtual method for raising the event
        protected virtual void OnClientCreated(EventArgs e)
        {
            var handler = ClientCreated;
            if (handler != null)
                handler(this, e);
        }
        // provide private specialized versions for convenience (e.g. to call it without
        // passing an argument)
        private void OnClientCreated()
        {
            OnClientCreated(EventArgs.Empty);
        }
    }
