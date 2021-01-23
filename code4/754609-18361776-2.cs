    if (!Page.IsPostBack)
            {
                User currUser = (User)Session["user"];
                 Dataset dsGrdDource = new Dataset();
                 dsGrdDource = from test in db.Tests
                                      select new
                                   {
                                      testId= test.TestId,
                                      courseName = test.Course.Name,
                                      onDate = test.OnDate.ToShortDateString() ,
                                      lastRegisterDate = test.LastRegisterDate
                                   };
           try
             { 
                  if(dsGrdDource !=null  )
               {
                    if(dsGrdDource.Rows.Count >0 )
                 {
                     gridAllTests.DataSource =dsGrdDource ;
                     gridAllTests.DataBind();
                     DataTable dt = (DataTable)dsGrdDource.Tables[0];
                    Session["taskTable"] = dt;
                 } 
               }
             }
                catch (Exception err)
                {
                    lblError.Text = err.Message.ToString();
                }
            }
