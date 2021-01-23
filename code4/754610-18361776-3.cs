    if (!Page.IsPostBack)
            {
                User currUser = (User)Session["user"];
               //  Dataset dsGrdDource = new Dataset();
                IEnumerable<DataRow> result = from test in db.Tests
                                      select new
                                   {
                                      testId= test.TestId,
                                      courseName = test.Course.Name,
                                      onDate = test.OnDate.ToShortDateString() ,
                                      lastRegisterDate = test.LastRegisterDate
                                   };
        
              DataTable dtgrdSource= query.CopyToDataTable<DataRow>();
           try
             { 
               
                     gridAllTests.DataSource =dtgrdSource;
                     gridAllTests.DataBind();
                   //  DataTable dt = (DataTable)dsGrdDource.Tables[0];
                    Session["taskTable"] = dtgrdSource;
                } 
             
                catch (Exception err)
                {
                    lblError.Text = err.Message.ToString();
                }
            }
