    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FutClient client;//<-- declared it here
        public async void button1_Click(object sender, EventArgs e)
        {
            client = new FutClient();// <--I changed this
            var loginDetails = new LoginDetails(email, password, secret, platform);
            try
            {
                var loginResponse = await client.LoginAsync(loginDetails);
                var creditsResponse = await client.GetCreditsAsync();
                label1.Text = creditsResponse.Credits.ToString();
            }
            catch (Exception ex)
            {
                this.textBox4.Text = ex.Message;
                //throw;
            }
        }
        private async void butGetTradepile_Click(object sender, EventArgs e)
        {
            //var client = new FutClient();
            var tradePileResponse = await client.GetTradePileAsync();
            Console.WriteLine(tradePileResponse);
        }
    }
