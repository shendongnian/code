    namespace WpfApplication25    {
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    public string ItemName{get;set;}
    public string CurrentPrice{get;set;}
    public string StartPrice{get;set;}
    
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(
                         @"data source=(local);
                         database=Aukcija;
                         integrated security=true;"))
            {
                DataTable aukcijeTable = new DataTable(); //novo
                ItemName = textBox1.Text;
                CurrentPrice = textBox3.Text;
                StartPrice = textBox2.Text;
                SqlCommand cmd = new SqlCommand("INSERT INTO Auctions (item_name, start_price, current_price ) VALUES (@item_name, @start_price, @current_price)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@start_price", textBox2.Text);
                cmd.Parameters.AddWithValue("@current_price", textBox3.Text);
                cmd.ExecuteNonQuery();           
                connection.Close();
    
    
    
            }
        }
    }}
