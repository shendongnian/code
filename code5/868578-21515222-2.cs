    class Form1 : Form
    {
        public Form1()
        { 
             InitializeComponent(); //Assumes the binding was set up via the gui to the bindingSource "settingsBindingSource"
    
             settingsBindingSource.DataSource = new MySettings();
        }
    
        //...
    
        private void SaveSettings(string path)
        {
             var ser = new XmlSerializer(typeof(MySettings));
             using(var writer = new StreamWriter(path);
             {
                  ser.Serialize(writer, (MySettings)settingsBindingSource.DataSource);
             }
        }
    
        private void LoadSettings(string path)
        {
             var ser = new XmlSerializer(typeof(MySettings));
             using(var reader = new StreamReader(path);
             {
                   settingsBindingSource.DataSource = (MySettings)ser.Deserialize(reader);
             }
        }
    }
