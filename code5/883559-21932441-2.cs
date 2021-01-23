        public Form1()
        {
            InitializeComponent();
             for (int x = 0; x <= 8939500; x++)
             {
                if(!string.IsNullorEmpty(lineuser) //<--- check the string is empty
             	{   
                    string[] values = lineuser.Split(' '); //<------the line's error
                    int userid, factoriduser;
                    foreach (string value in values)
                    {
                      userid = Convert.ToInt32(values[0]);
                      factoriduser = Convert.ToInt32(values[1]);
                      userscore = Convert.ToSingle(values[2]);
                      a[userid][factoriduser] = userscore;
                    }
                }
             }
             for (int y = 0; y <= 114360000; y++)
             {
                lineitem = fileitem.ReadLine();
  
                if(!string.IsNullorEmpty(lineitem) //<--- check the string is empty
                {
                   
                   string[] valuesi = lineitem.Split(' ');
                   int itemid, factoriditem;
                   foreach (string value in valuesi)
                   {
                     itemid = Convert.ToInt32(valuesi[0]);
                     factoriditem = Convert.ToInt32(valuesi[1]);
                     itemscore = Convert.ToSingle(valuesi[2]);
                     b[itemid][factoriditem] = itemscore;
                   }
                }
            }
        }
