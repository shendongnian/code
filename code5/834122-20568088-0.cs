    public ActiveTicketDetail()
            {
                InitializeComponent();
                WCFClient.GetTicketReplyListCompleted += new EventHandler<GetTicketReplyListCompletedEventArgs>(WCFClient_GetTicketReplyListCompleted);
                WCFClient.GetTicketReplyListAsync(84);
    
    
    
            }
    
            void WCFClient_GetTicketReplyListCompleted(object sender, GetTicketReplyListCompletedEventArgs e)
            {
                List<TicketReplyModel> TickteReptyList = new List<TicketReplyModel>();
                TickteReptyList = e.Result.ToList();
                TickteReptyList.ForEach(item =>
                {
                    TextBlock txtBl1 = new TextBlock();
                    txtBl1.Text = item.ContentText;
                    txtBl1.Padding = new Thickness(5);
                    txtBl1.FontSize = 18;
                    TextBlock txtBl2 = new TextBlock();
                    txtBl2.Text = item.Date.ToShortDateString();
                    txtBl2.Padding = new Thickness(5);                
                    txtBl2.FontSize = 14;
                    txtBl2.HorizontalAlignment = HorizontalAlignment.Right;
                    StackPanel st = new StackPanel();
                    st.Children.Add(txtBl1);
                    st.Children.Add(txtBl2);
                    
                    st.Width = 400;                
                    st.HorizontalAlignment = item.IsClient ? HorizontalAlignment.Right : HorizontalAlignment.Left;
                    st.Margin = new Thickness(5);
                    string fileName = item.IsClient ? "Images/MessagecollorMe.png" : "Images/MessagecollorBank.png";
                    BitmapImage image = new BitmapImage(new Uri(fileName, UriKind.Relative));
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = image;
                    st.Background = brush;
                    Tikcetst.Children.Add(st);
                });
            }
