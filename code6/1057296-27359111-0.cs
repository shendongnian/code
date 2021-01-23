    public partial class Search : Form
    {
      private OleDbConnection connection = new OleDbConnection();
      DataTable DT = new DataTable();
      public Search()
      {
        InitializeComponent();
        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\StockRecord.accdb; Persist Security Info=False;";
       
        try
        {
          connection.Open();
          SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", connection);
          da.Fill(DT);
          DataView DV = new DataView(DT); //DT has been declared as a global variable for a DataTable.
          DV.RowFilter = String.Format("Product_Name LIKE '%{0}%'", radTextBox1.Text);
          dataGridView1.DataSource = DV;
          connection.Close();
         }
         catch (Exception S)
         {
           MessageBox.Show("" + S);
         }
      }
    }
