    namespace WpfApplication25
    {
        /// <summary> <br>
        /// Interaction logic for MainWindow.xaml <br>
        /// </summary> <br> 
        public partial class MainWindow : Window <br>
        {
    
            int count = 120;
            System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
    
    private DataTable aukcijeTable;        
    public MainWindow()
            {
                InitializeComponent();
    
                tmr.Interval = new TimeSpan(0, 0, 1);
                tmr.Tick += new EventHandler(tmr_Tick);
    
                aukcijeTable = new DataTable();
                SqlConnection conn = new SqlConnection(@"data source=(local);database=Aukcija;integrated security=true;");
                SqlDataAdapter aukcDa = new SqlDataAdapter("select * from auctions", conn);
    
                aukcDa.Fill(aukcijeTable);
                aukcija_bazeDataGrid.DataContext = aukcijeTable;
    
    
            }
    
    
    
            void tmr_Tick(object sender, EventArgs e)
            {
                label1.Content = count -= 1;
                if (count == 0 )
                {
                    System.Windows.Forms.MessageBox.Show("Auction completed");
                    tmr.Stop();
                    count = 120;
                }
                else
                {
    
    
                }
    
            }
    
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                Form1 popup = new Form1();
                popup.ShowDialog();
                popup.Dispose();
            }
    
            private void button3_Click(object sender, RoutedEventArgs e)
            {
                Form2 popup = new Form2();
                if(popup.ShowDialog()== DialogResult.OK){
                     
                    var newRow = aukcijeTable.NewRow();
                    newRpw[0] = popup.ItemName;
                    newRow[1] = popup.StartPrice;
                    newRow[2] = popup.CurrentPrice;
                    aukcijeTable.Rows.Add(newRow);
                    aukcija_bazeDataGrid.Refresh();
    
                }
    
                popup.Dispose();
            }
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                tmr.Start();
    
                using (SqlConnection conn = new SqlConnection(@"data source=(local);database=Aukcija;integrated security=true;")) 
    
                {
                    DataTable cena1 = new DataTable();
                    conn.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(" UPDATE auctions SET current_price = current_price + 1", conn);
                    SqlCommand cmd = new SqlCommand ("UPDATE auctions SET current_price = current_price + 1", conn);
                    DA.Fill(cena1);
                    //DA.Update(cena1);
                    cmd.ExecuteNonQuery();
                    SqlCommandBuilder cb = new SqlCommandBuilder(DA); //novo
                    DA.Update(cena1); //novo
                    conn.Close(); 
    
                }
    
            }
    
    
            private void aukcija_bazeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
            }
    
            private void button4_Click(object sender, RoutedEventArgs e)
            {
    
                tmr.Start();
    
            }
    
            private void button5_Click(object sender, RoutedEventArgs e)
            {
                tmr.Stop();
                System.Windows.Forms.MessageBox.Show("Auction completed!");
                count = 120;
            }
    
    
        }
    }
    
            
