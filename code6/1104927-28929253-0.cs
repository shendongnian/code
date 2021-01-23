    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Page.IsPostBack)
        {
            //Question
            lblQuestion1.Text = "Which of the following is not a country in Europe?";
            //Answers
            lstAns1.Items.Add(new ListItem("Enland", "0"));
            lstAns1.Items.Add(new ListItem("Germany", "0"));
            lstAns1.Items.Add(new ListItem("France", "0"));
            lstAns1.Items.Add(new ListItem("Canada", "1"));
        }
    }
