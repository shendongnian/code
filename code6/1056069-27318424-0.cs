    using System;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private string json = @"
    {
        ""Date"": ""0000-00-00 00:00:00""
    }
    ";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var myClass = new MyClass();
    
                var deserializeObject = JsonConvert.DeserializeObject<MyClass>(json,
                    new JsonSerializerSettings {ContractResolver = new CustomDateContractResolver()});
    
                string serializeObject = JsonConvert.SerializeObject(myClass, Formatting.Indented,
                    new JsonSerializerSettings {ContractResolver = new CustomDateContractResolver()});
            }
        }
    
        internal class MyClass
        {
            public DateTime DateTime { get; set; }
        }
    
        internal class CustomDateContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                JsonContract contract = base.CreateContract(objectType);
                bool b = objectType == typeof (DateTime);
                if (b)
                {
                    contract.Converter = new ZerosIsoDateTimeConverter("yyyy-MM-dd hh:mm:ss", "0000-00-00 00:00:00");
                }
                return contract;
            }
        }
    }
