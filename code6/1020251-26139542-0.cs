    using System;
    using System.Configuration;
    using System.Windows.Forms;
    namespace MultipleConfig
    {
        /* Note :- Create multiple config files.
        */
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                System.Configuration.ExeConfigurationFileMap configFile = new System.Configuration.ExeConfigurationFileMap();
                configFile.ExeConfigFilename = "MyConfig.config";
    
                Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFile, System.Configuration.ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = config.AppSettings.Settings;
    
                string fName = ConfigurationManager.AppSettings["FirstName"];
                string lName = settings["LastName"].Value;
                string country = settings["Country"].Value;
    
                MessageBox.Show(String.Concat(fName, " ", lName, "\nCountry ", country), this.Text);
            }
        }
    }
