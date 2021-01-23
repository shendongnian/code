     protected void Page_Load(object sender, EventArgs e)
        {
            MyFruit = Session["Fruitname"] as List<string>;
            //Create new, if null
            if (MyFruit == null)
                MyFruit = new List<string>();
            ListBox1.DataSource = MyFruit;
            ListBox1.DataBind();
       
               
        }
        public List<string> MyFruit { get; set; }
    }
