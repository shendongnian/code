    using Microsoft.VisualBasic; //add this statement
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            string filesplit = "|split|";
            string stub;
            string[] opt;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                FileSystem.FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared);
                stub = Strings.Space(Convert.ToInt32(FileSystem.LOF(1)));
                FileSystem.FileGet(1, ref stub);
                FileSystem.FileClose(1);
                opt = Strings.Split(stub, filesplit);
            }
        }
    }
