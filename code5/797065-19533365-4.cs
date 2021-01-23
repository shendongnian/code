                string x1 = "8:7:15";//1st column value
                string x2 = "9:15:12";//2ndcolumn value
                string x3 = "10:3:4";//3rd column value
                string x4 = "1:1:1";
                string x5 = "1:1:1";
        // , I just assign 5 values,but you can assign more than lot values  in this array 
                string[] xxA = new string[5];
                xxA[0] = x1;
                xxA[1] = x2;
                xxA[2] = x3;
                xxA[3] = x4;
                xxA[4] = x5;
        
               
                string Tvalue1 = "00";
                string Tvalue2 = "00";
                string Tvalue3 = "00";
          //Now the xxA has 5 rows (No problem for how many rows ) So this foreach will round 5 time 
                if(int i = 0; i < GridView1.Rows.Count; i++)//Now xxA.Length is 5
                {
                   string x = GridView1.Rows[i].Cells[9].ToString();
                   int n=GridView1.Rows.Count;
                   string[] xxA=new string[n]; 
                    xxA[i] = x; 
          //Here is the some logic's for the calculation and formating  
                    string[] Cx1 = xxA[i].Split(':');
                    Tvalue1 = (Convert.ToInt32(Tvalue1.Remove(Tvalue1.Length - 1)) + Convert.ToInt32(Cx1[0])) + ":".ToString();
                    Tvalue2 = (Convert.ToInt32(Tvalue2.Remove(Tvalue2.Length - 1)) + Convert.ToInt32(Cx1[1])) + ":".ToString();
                    Tvalue3 = (Convert.ToInt32(Tvalue3.Remove(Tvalue3.Length - 1)) + Convert.ToInt32(Cx1[2])) + ":".ToString();
                }
                string FInalValue = Tvalue1 + Tvalue2 + Tvalue3.Remove(Tvalue3.Length - 1);
