         public partial class MainWindow : Window
         {
    
             public ObservableCollection<EmailEntry > ListBoxData{get;set;}
    
             public MainWindow()
             {
                 ListBoxData = new ObservableCollection<EmailEntry >();
                 InitializeComponents();
             }
    
            private void newEmail(object sender, DoWorkEventArgs e)
            {
                 List<Message> allEmail = FetchAllMessages(hostname, port, useSsl, username, password);
                
    
                foreach (Message singleEmail in allEmail)
                {
                    var mailData = new ListBoxDataClass { theMessage = singleEmail, truncate = 40 };
                    readyUpListBoxData(mailData);
                    ListBoxData.Add(new EmailEntry { from = mailData.displayName, subject = mailData.partOfBody, messageID = singleEmail.Headers.MessageId.ToString() });   
                }
          }
