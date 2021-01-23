        public class foo
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamReader fileitem;
            StreamReader fileuser;
            public lineUser{
                get{return fileuser;}
                set{fileuser=Value;}
            }
            public foo()
            {
                fileitem = new StreamReader(Path.Combine(desktop, "one.txt"));
                fileuser = new StreamReader(Path.Combine(desktop, "two.txt"));
            }
        }
   
        public Form1()
        {
            InitializeComponent();
            for (int x = 0; x <= 8939500; x++)
            {
                Foo fo=new Foo();
                lineuser = fo.fileuser.ReadLine();                //The error line
                if (!string.IsNullOrEmpty(lineuser))
                {
                    string[] values = lineuser.Split(' ');
                    int userid, factoriduser;
                    foreach (string value in values)
                    {
