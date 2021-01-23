    protected void Page_Load(object sender, EventArgs e)
    {
            // you do not use !IsPostBack here
            //count of func must be equal with 'Query.Length'
            string[,] arr ={
                             {"func1","hello world"},
                             {"func2","Hello ASP.NET"}
                         };
            for (int i = 0; i < Query.Length; i++)//I assume length is 2
            {
                 Button btn = new Button();
                 btn.ID = arr[i, 0];
                 btn.CommandArgument = arr[i, 1];
                 btn.Click += new EventHandler(btn_Click);
                 btn.Text = i.ToString();
                 pagingPanel.Controls.Add(btn);
           }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        System.Reflection.MethodInfo methodInfo = typeof(_Default2).GetMethod(btn.ID); //_Default2 is class name of code behind
        if (methodInfo != null)
        {
            object[] parameters = new object[] { btn.CommandArgument};
            methodInfo.Invoke(this,parameters);
        }
    }
    public void func1(object args)
    {
        string test = args.ToString();
        Response.Write(test);
    }
    public void func2(object args)
    {
        string test = args.ToString();
        Response.Write(test);
    }
