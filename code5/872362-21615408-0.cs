    namespace contacts
    {
        public partial class MainPage : PhoneApplicationPage
        {
            int TapCount = 0;
            var contacts = new Contacts();
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
                SearchContacts(String.Empty); 
            }
            void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
            {
                ContactList.ItemsSource = e.Results;
            }
            private void SearchContacts(string searchterm)
            {
                contacts.SearchAsync(searchterm, FilterKind.DisplayName, null);
            }
        }
    }
