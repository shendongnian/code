     protected void Button1_Click1(object sender, EventArgs e)
        {
           
           // Session["Fruitname"] = TbxName.Text; // my session i have made
            MyFruit = Session["Fruitname"] as List<string>;
            //Create new, if null
            if (MyFruit == null)
                MyFruit = new List<string>();
            MyFruit.Add(TbxName.Text);
            Session["Fruitname"] = MyFruit;
    {
    public List<string> MyFruit { get; set; }
    }
