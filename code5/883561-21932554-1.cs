        public Form1()
        {
            InitializeComponent();
            string lineuser;
            // OPEN
            using(StreamReader fileuser = new StreamReader("c:\\USER_SVD_FULL.txt"))
            {
                // USE
                while((lineuser = fileuser.ReadLine()) != null)
                {
                     string[] values = lineuser.Split(' ');
                     ....
                }
            } //CLOSE & DISPOSE
            ....
            string lineitem;
            using(StreamReader fileitem = new StreamReader("c:\\ITEM_SVD_FULL.txt"))
            {
                while((lineitem = fileitem.ReadLine()) != null)
                {
                    string[] valuesi = lineitem.Split(' ');
                    ....
                }
            }
 
 
