    protected void Page_Load(object sender, EventArgs e)
            {
                //dtcStartDate.MaxDate = System.DateTime.Today;
                dtcBuildStartDate.MaxDate = DateTime.Now.AddMonths(-1);
                dtcStartDate.MaxDate = DateTime.Now.AddMonths(-1);
                dtcEndDate.MaxDate = System.DateTime.Today;
                dtcBuildEndDate.MaxDate = System.DateTime.Today; ;
                lblErrorMsg.Text = "";
    
                // When the page loads 1st time
    
                if (!Page.IsPostBack)
                {
                    try
                    {
                        Rd1Month.Checked = true;
                        Rd1BuildMonth.Checked = true;
                        dtcEndDate.SelectedDate = System.DateTime.Today; // set end date calendar to today's date
                        dtcBuildEndDate.SelectedDate = System.DateTime.Today;
                        dtcStartDate.SelectedDate = DateTime.Now.AddMonths(-1);
                        dtcBuildStartDate.SelectedDate = DateTime.Now.AddMonths(-1);
                    }
    
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text += ex.Message;
                    }
    
                }
    
                SetDateBoxEnabled();
            }
    
            private void SetDateboxEnabled()
            {
                if (Rd4BuildMonth.Checked)
                {
                    dtcBuildStartDate.Enabled = false;
                }
                else
                {
                    dtcBuildStartDate.Enabled = true;
                }
    
                if (Rd4Month.Checked)
                {
                    dtcStartDate.Enabled = false;
                }
                else
                {
                    dtcStartDate.Enabled = true;
                }
            }
