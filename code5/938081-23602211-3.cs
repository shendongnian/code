    protected void Page_Load(object sender, EventArgs e)
        {
            List<String> listQuestion = new List<String>();
            foreach(string question in ...)
            {
                listQuestion.Add(question);
            }
            rptQuestion.DataSource = listQuestion;
            rptQuestion.DataBind();
        }
