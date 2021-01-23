        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                List<double> numbers = new List<double>();
                Session["numbers"] = numbers;
            }  
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["numbers"] != null)
            {
                List<double> numbersResult = Session["numbers"] as List<double>;
                double number = Convert.ToDouble(TextBox1.Text);
                numbersResult.Add(number);
                Session["numbers"] = numbersResult;
            }
        }
    
