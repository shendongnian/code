        public ObservableCollection<Client> Clients
        {
            get { return (ObservableCollection<Client>)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }
        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(ObservableCollection<Client>),   typeof(MainWindow));
