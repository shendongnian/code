    ...
    
        using System.Xml;
        
        namespace WindowsFormsApplication2
        {
            public partial class Form2 : Form
            {
                XmlDocument activeDoc=new XmlDocument();
                String path;
                public Form2(string _path)
                {
                    path = _path;
                    InitializeComponent();
                }
        
        
                private void checkBox1_CheckedChanged(object sender, EventArgs e)
                {
                        MessageBox.Show(Convert.ToString(sender),Convert.ToString(e));
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    save(path);
                }
                private void save(string path){
                    activeDoc.Save(path);
                }
            }
        }
