    public partial class frmShop : Form
    {
    	private string ConnectionString
    	{
    		get { return WindowsFormsApplication1.Properties.Settings.Default.BinaryStringsDictionaryConnectionString1; }
    	}
    
        public frmShop()
        {
            InitializeComponent();
        }
    	
    	private SqlConnection CreateConnection()
    	{
    		var conn = new SqlConnection(ConnectionString);
    		conn.Open();
    		return conn;
    	}
    
        private void frmShop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'binaryStringsDictionaryDataSet.ShopSentences' table. You can move, or remove it, as needed.
            this.shopSentencesTableAdapter.Fill(this.binaryStringsDictionaryDataSet.ShopSentences);
        }
    	private void GetSentence()
        {
    		try
    		{
    			using (var conn = CreateConnection())
    			{
    				var BinaryInt = int.Parse(txtBinaryString.Text);
    				var commandString = "SELECT Sentence FROM ShopSentences WHERE BinaryStrings = @BinaryString";
    				using (var Command = new SqlCommand(commandString, conn))
    				{
    					Command.Parameters.Add("@BinaryString", System.Data.SqlDbType.Int).Value = BinaryInt;
    					
    					using (var readSentence = Command.ExecuteReader())
    					{
    						while (readSentence.Read())
    						{
    							txtSentence.Text = (readSentence["Sentence"].ToString());
    							Fit = 1;
    						}
    					}
    				}
    			}
    		 }
    
    		catch (Exception e)
    		{
    			Console.WriteLine(e.ToString());
    		}
    	}
    	
    	private void InsertData()
        {
            try
            {
    			using (var conn = CreateConnection())
    			{
    				var commandString = "INSERT INTO ShopSentences (BinaryStrings,Sentence,RowNumber) VALUES (@NewBinaryString,@NewSentence,@NewRowNumber)";
    				using (var comm = new SqlCommand(commandString, conn))
    				{
    					comm.Parameters.AddWithValue("@NewBinaryString", GenerateCode());
    					comm.Parameters.AddWithValue("@NewNewSentence", txtSentence.Text);
    					comm.Parameters.AddWithValue("@NewRowNumber", NewRowNum());
    					
    					comm.ExecuteNonQuery();
    				}
    			}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //Checking the banary code in the last row
        string GenerateCode()
        {
            string RowNo = RowFind();
            int Row = int.Parse(RowNo);
            int Code = Row + 1;
            string Cd = Convert.ToString(Code, 2);
            int Ln = Cd.Trim().Length;
            if (Ln == 3)
            {
                Cd = "100" + Cd;
            }
            else if (Ln == 4)
            {
                Cd = "10" + Cd;
            }
            else if (Ln == 5)
            {
                Cd = "1" + Cd;
            }
            return Cd;
        }
        //Finding the last row
        string RowFind()
        {
    		using (var conn = CreateConnection())
    		{
    			var commandString = "SELECT * FROM ShopSentences";
    			using (var comm = new SqlCommand(commandString, conn))
    			{
    				using (var sda = new SqlDataAdapter(queryString, Connection))
    				{
    					using (DataTable dt = new DataTable("ShopSentences"))
    					{
    						sda.Fill(dt);
    						return dt.Rows[dt.Rows.Count - 1]["RowNumber"].ToString();
    					}
    				}
    			}
    		}
        }
    
        string NewRowNum()
        {
            var Row = RowFind();
            var CalcRow = int.Parse(Row) + 1;
            return CalcRow.ToString();
       
    }
    }
