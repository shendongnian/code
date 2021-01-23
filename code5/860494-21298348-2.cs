    protected void Page_Load(object sender, EventArgs e)
    {
         ds = DA.DsQndA(1);//pass quiz id to fill dataset with requested quiz.
         numOfRows = ds.Tables[0].Rows.Count;//so we know when to get redirected to results page
         
         if (Page.IsPostBack)
         {
              myNum += 1;
         }
     
         //if we are at over max questions then go right to results page
         if (myNum >= numOfRows)
             Response.Redirect("~/QuizResult.aspx");
    
         Question.InnerText = ds.Tables[0].Rows[myNum]["Question"].ToString();
    
         Btn1.Click += BtnClick;
         Btn2.Click += BtnClick;
         Btn3.Click += BtnClick;
         Btn4.Click += BtnClick;
    
    }
