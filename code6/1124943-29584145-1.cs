    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Contacts;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    
    namespace ContactsSearch
    {
      public sealed partial class MainPage : Page
      {
        public MainPage()
        {
          this.InitializeComponent();
          this.NavigationCacheMode = NavigationCacheMode.Required;
        }
    
        ContactStore store;
        bool loading = false;
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          if (store == null)
            GetStoreAsync().GetType(); // GetType avoids compiler warning
        }
    
        async Task GetStoreAsync()
        {
          store = await ContactManager.RequestStoreAsync();
          input.IsEnabled = true;
          Debug.WriteLine("Ready!");
        }
    
        private async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
          if (store == null || loading)
            return;
    
          string search = (sender as TextBox).Text;
    
          Debug.WriteLine("Looking for: '{0}'", search);
          loading = true;
          candidates.Opacity = 0.8;
          candidates.Items.Clear();
    
          IReadOnlyList<Contact> contacts = new List<Contact>();
          if (string.IsNullOrWhiteSpace(search))
            contacts = await store.FindContactsAsync();
          else
            contacts = await store.FindContactsAsync(search);
    
          foreach (var c in contacts)
          {
            var email = c.Emails.FirstOrDefault();
            if (email == null)
              continue;
            candidates.Items.Add(new ContactInfo { Name = c.DisplayName, Email = email.Address });
          }
    
          Debug.WriteLine("Found {0} contacts", candidates.Items.Count);
          loading = false;
          candidates.Opacity = 1;
        }
      }
    
      public class ContactInfo
      {
        public string Name { get; set; }
        public string Email { get; set; }
      }
    }
