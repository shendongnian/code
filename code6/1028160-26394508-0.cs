    using System;
    using System.Net;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                string url = @"http://www.bom.gov.au/fwo/IDN60901/IDN60901.95764.json";
                var client = new WebClient();
                var s = client.DownloadString(url);
                var deserializeObject = JsonConvert.DeserializeObject<SampleResponse1>(s);
            }
        }
    }
