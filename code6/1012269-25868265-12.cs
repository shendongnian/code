    public void button1_Click(object sender, EventArgs e)    
    {    
        try
        {        
            if (openFileDialog1.FileName != string.Empty)
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    int count = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        UserData d = new UserData();
                        string[] parts = line.Split(':');
                        d.UserName = parts[0].Trim();
                        d.Password = parts[1].Trim();
                        data.Add(d);
                    }
    
                    // At the loop end you could use the List<UserData> like a normal array
                    foreach(UserData ud in data)
                    {
                        Console.WriteLine("User=" + dd.UserName + " with password=" + dd.Password);
                    }
                }
            }
        }
    }
    public void button2_Click(object sender, EventArgs e)
    {
        try
        {
             if(data.Count() == 0)
             {
                 MessageBox.Show("Load user info first");
                 return;
             }
    
             var url = @"https://mail.google.com/mail/feed/atom";
             var encoded = TextToBase64(data[0].UserName + ":" + data[0].Password);         
             .....
