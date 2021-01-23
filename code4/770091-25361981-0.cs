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
