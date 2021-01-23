      public partial class TestForm1 : TestForm
        {
            public TestForm1 ()
            {
                InitializeComponent();
            }
     
            private void button1_Click(object sender, EventArgs e)
            {           
                comboBox1.Items.Add(new ComboBoxItem("value1","text1"));
     
                foreach (object o1 in comboBox1.Items)
                {
                    if (o1 is ComboBoxItem)
                        MessageBox.Show("value=" + ((ComboBoxItem)o1).Value + "; text=" + ((ComboBoxItem)o1).Text);
                }
            }
        }
     
        public class ComboBoxItem
        {
            public string Value;
            public string Text;
            public ComboBoxItem(string val, string text)
            {
                Value = val;
                Text = text;
            }
     
            public override string ToString()
            {
                return Text;
            }
        }
