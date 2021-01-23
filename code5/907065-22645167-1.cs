    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace SandboxForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var button = new Button();
                this.Controls.Add(button);
    
                button.Click += button_Click;
            }
    
            private async void button_Click(object sender, EventArgs e)
            {
                var factory = new ChannelFactory<IService>("SandboxForm.IService"); //Configured in app.config
                IService proxy = factory.CreateChannel();
    
                string result = await proxy.GetTestAsync();
    
                MessageBox.Show(result);
            }
        }
        
        [ServiceContract]
        public interface IService
        {
            [OperationContract(Action = "http://tempuri.org/IService/GetTest", ReplyAction = "http://tempuri.org/IService/GetTestResponse")]
            Task<string> GetTestAsync();
        }
    }
