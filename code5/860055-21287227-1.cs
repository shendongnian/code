    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace XmlDragDropExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.AllowDrop = true;
                this.DragEnter += new DragEventHandler(Form1_DragEnter);
                this.DragDrop += new DragEventHandler(Form1_DragDrop);
            }
            private void Form1_DragDrop(object sender, DragEventArgs e)
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string fileLoc in filePaths)
                {
                    var xdoc = XDocument.Load(fileLoc);
                    foreach (var element in xdoc.Root.Descendants())
                    {
                        textBox1.Text += element.Name + "\r\n";
                    }
                }
            }
            private void Form1_DragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            }
        }
    }
    
