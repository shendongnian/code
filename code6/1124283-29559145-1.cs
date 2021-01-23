    public partial class MainMenu : Form
    {
        SqlConnection _myConnection;
        public Form1()
        {
            InitializeComponent();
            this._myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }
        public void ExecuteAQueryExample()
        {
            if (this._myConnection.State != ConnectionState.Open) this._myConnection.Open();
            using (var command = this._myConnection.CreateCommand())
            {
                // ...
            }
            this._myConnection.Close();
        }
    }
