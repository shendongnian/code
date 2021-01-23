     protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Attributes.Add("actIndex", "1");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Value = Button2.Attributes["actIndex"].ToString();//1
            Button2.Attributes.Remove("actIndex");
            Button2.Attributes.Add("actIndex", "2");
             Value = Button2.Attributes["actIndex"].ToString();//2
           
        }
