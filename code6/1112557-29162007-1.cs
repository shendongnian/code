    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    Class1 obj = new Class1();
    static List<Class1> lst = new List<Class1>();
        
    protected void Button1_Click(object sender, EventArgs e)
    {
       obj.Name = TextBox1.Text;
       obj.Address = TextBox2.Text;
       lst.Add(obj);
       GridView1.DataSource = lst; 
       GridView1.DataBind();
    }
