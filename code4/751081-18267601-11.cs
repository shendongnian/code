     protected void Page_Load(object sender, EventArgs ea)
            {
                ImageButton testbtn = new ImageButton();
                testbtn.OnClientClick = "return testbook('15000')";
                form1.Controls.Add(testbtn);
    
            }
