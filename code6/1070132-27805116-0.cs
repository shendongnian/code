				I hope below code will help you.
--------------------------------------------------------
		
                         protected void Page_Load(object sender, EventArgs e)
								{
									if (!this.IsPostBack)
									{
										TemplateField tfield = new TemplateField();
										tfield.HeaderText = "View";
										GridView1.Columns.Add(tfield);
									}
									this.BindGrid();
								}
								private void BindGrid()
								{
									DataTable dt = new DataTable();
									dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),
												new DataColumn("Name", typeof(string))  });
									dt.Rows.Add(1, "A");
									dt.Rows.Add(2, "B");
									GridView1.DataSource = dt;
									GridView1.DataBind();
								}
								protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
								{
									if (e.Row.RowType == DataControlRowType.DataRow)
									{
										LinkButton lnkView = new LinkButton();
										lnkView.ID = "lnkView";
										lnkView.Text = "View";
										lnkView.Click += ViewDetails;
										lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
										e.Row.Cells[2].Controls.Add(lnkView);
									}
								}
								protected void ViewDetails(object sender, EventArgs e)
								{
									LinkButton lnkView = (sender as LinkButton);
									GridViewRow row = (lnkView.NamingContainer as GridViewRow);
									string id = lnkView.CommandArgument;
									ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Id: " + id + "')", true);
								}
