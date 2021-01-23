    public class SQLServerClass
    {
        public SQLServerClass()
        {
            LoginCommand = new RelayCommand<object>(LoginCommandExecute, LoginCommandCanExecute);
        }
        public void ConnectSQLServer(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=tcp:172.16.1.71;Initial Catalog=Sample;User ID=sa;Password=hbkrko");
                conn.Open();
                MessageBox.Show("success");
            }
            catch
            {
                MessageBox.Show("db error");
            }
        }
        public ICommand LoginCommand { get; set; }
        private void LoginCommandExecute(object arg)
        {
            ConnectSQLServer(this, new RoutedEventArgs());
        }
        private bool LoginCommandCanExecute(object arg)
        {
            return true;
        }
    }
