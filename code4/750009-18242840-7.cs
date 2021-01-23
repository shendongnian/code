    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void AddValue_Click(object sender, EventArgs e)
        {
            using (ChannelFactory<ICalculatorService> facotry = new ChannelFactory<ICalculatorService>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/MyServiceAddress")))
            {
                ICalculatorService proxy = facotry.CreateChannel();
                
                // Generate a random number to send to the service
                Random rand = new Random();
                var value = rand.Next(3, 20);
                // Send the random value to Windows service
                proxy.Add(value);
            }
        }
        private void GetAllValues_Click(object sender, EventArgs e)
        {
            using (ChannelFactory<ICalculatorService> facotry = new ChannelFactory<ICalculatorService>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/MyServiceAddress")))
            {
                ICalculatorService proxy = facotry.CreateChannel();
                // Get all the numbers from the service
                var returnedResult = proxy.GetAllNumbers();
                // Display the values returned by the service
                MessageBox.Show(string.Join("\n", returnedResult));
            }
        }
    }
