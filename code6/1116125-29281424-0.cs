     using System.Data.Entity;
        private Database1Entities  _context = new Database1Entities (); 
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            _context.Table.Load();
            tableViewSource.Source = _context.Table.Local;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            _context.SaveChanges();
            tableDataGrid.Items.Refresh(); 
        }
