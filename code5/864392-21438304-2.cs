    public class BarClientsViewModel
    {
        private List<string> _clientID;
        private List<string> _emailAddresses;
        public BAR_Clients BAR_Clients;
        public veForms_BAR_Clients veForms_BAR_Clients;
        public string InvoiceMode;
        [EmailFormatVerification]
        public string NewEmailAddress;
        public Exceptions Exceptions;
        public BarClientsViewModel(IEnumerable<veForms_BAR_Clients> meditechClients)
        {
            _clientID = new List<string>();
            foreach(veForms_BAR_Clients client in meditechClients)
            {
                _clientID.Add(client.Number);
            }
            _emailAddresses = new List<string>();
        }
        public void FindEmailAddresses(IEnumerable<BAR_Clients> barClients)
        {
            string emailAddressLine = "";
            foreach(BAR_Clients client in barClients)   // There will only be one client here
            {
                emailAddressLine = client.EmailAddress;
                InvoiceMode = client.InvoiceMode;
            }          
            string[] temp = emailAddressLine.Split(';');
            _emailAddresses = new List<string>();
            _emailAddresses = temp.ToList();
        }
        public string AddEmail(IEnumerable<BAR_Clients> barClients, string emailAddress)
        {
            string emailAddressLine = "";
            foreach (BAR_Clients client in barClients)   // There will only be one client here
            {
                emailAddressLine = client.EmailAddress;
                emailAddressLine = String.Format("{0};{1}", emailAddressLine, emailAddress);
            }
            return emailAddressLine;
        }
        public IEnumerable<SelectListItem> MeditechClientID
        {
            get { return new SelectList(_clientID); }
        }
        public IEnumerable<String> EmailAddressesOfChosenClient
        {
            get { return _emailAddresses; }
        }
        
        public IEnumerable<SelectListItem> InvoiceOptions
        {
            get { return new SelectList(new List<string>() { "PRINT", "EMAIL", "BOTH" }); }
        }
    }
