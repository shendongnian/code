        public Form1()
        {
            InitializeComponent();
            using(StreamReader fileuser = new StreamReader("c:\\USER_SVD_FULL.txt"))
            {
                while((lineuser = fileuser.ReadLine()) != null)
                {
                     lineuser = fileuser.ReadLine();
                     string[] values = lineuser.Split(' ');
                     ....
                }
            }
 
