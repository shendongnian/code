    // create winforms project on form1 drag a textbox (testbox1)  
    // and a button (button1) with a button click event handler  
    // this updates the textbox when the button is clicked
    
    using System;  
    using System.Collections.Generic;  
    using System.ComponentModel;  
    using System.Data;  
    using System.Drawing;  
    using System.Linq;  
    using System.Text;  
    using System.Windows.Forms;   
  
    namespace WindowsFormsApplication3  
    {  
        public partial class Form1 : Form  
        {  
            MyClass Myobj = new MyClass();  
            public Form1()  
            {  
                InitializeComponent(); 
   
                /* propertyname, datasource, datamember */  
                textBox1.DataBindings.Add("Text", Myobj, "Unit");  
            }
            public class MyClass : INotifyPropertyChanged
            {
                private int unit = 3;
                /* property change event */
                public event PropertyChangedEventHandler PropertyChanged;  
                public int Unit
                {
                    get
                    {
                        return this.unit;
                    }
                    set
                    {
                        if (value != this.unit)
                        {
                            this.unit = value;
                            NotifyPropertyChanged("Unit");
                        }
                    }
                }
                private void NotifyPropertyChanged(String propertyName)     
                {
                    PropertyChangedEventHandler handler = PropertyChanged;  
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
               Myobj.Unit += 4;
            }
        }
    }
