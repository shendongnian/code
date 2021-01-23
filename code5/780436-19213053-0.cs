    public class ContactsViewModel : ViewModelBase
    {
        public ContactsViewModel()
        {
            Contacts cons = new Contacts();
            cons.SearchAsync(String.Empty, FilterKind.None, null);
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
        }
       
        void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            try
            {
               
                PhoneContactsList = new List<Contact>(e.Results.OrderBy(c => c.DisplayName));
                System.Diagnostics.Debug.WriteLine("PhoneContacts phone" + PhoneContactsList);
            }
            catch (System.Exception)
            {
                //That's okay, no results
            }
        }
       
        //--------------------------------
        private List<Contact> _phoneContactsList;
        public List<Contact> PhoneContactsList
        {
            get { return _phoneContactsList; }
            set
            {
                _phoneContactsList = value;
                RaisePropertyChanged("PhoneContactsList");
            }
        }
    }
