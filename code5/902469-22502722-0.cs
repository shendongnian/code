    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class FormFULProgress : Form, INotifyPropertyChanged
        {
            private int Perc = 50;
    
            public FormFULProgress()
            {
                InitializeComponent();
    
                progressBar1.Maximum = 100;
    
                progressBar1.DataBindings.Add("Value", this, "MyProperty");
            }
    
            public int MyProperty
            {
                get { return Perc; }
                set
                {
                    Perc = value;
                    OnPropertyChanged("MyProperty");
                }
            }
    
            // Declare the event 
            public event PropertyChangedEventHandler PropertyChanged;
    
            // Create the OnPropertyChanged method to raise the event 
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.MyProperty = 75;
            }
    
        }
    }
