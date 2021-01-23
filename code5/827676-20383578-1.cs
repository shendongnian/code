    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != null)
            {
                int option = DropDownList1.SelectedIndex;
                var myList2 = new List<string>();
                myList2.Add("Test");
                myList2.Add("Test");
                var myList3 = new List<string>();
                switch (option)
                {
                    case 1:
                        if (myList2.Count > 0)
                        {
                            //GridView1.DataSource = myList2;
                            //GridView1.DataBind();
                            //GridView1.Visible = true;
                            MainMultiview.SetActiveView(View1);
                        }
                        else
                        {
                            lblMessage.BackColor = System.Drawing.Color.Yellow;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "No Data!";
                        }
                        break;
                    case 2:
                        if (myList2.Count > 0)
                        {
                            //GridView1.Visible = false;
                            //GridView2.DataSource = myList3;
                            //GridView2.DataBind();
                            //GridView2.Visible = true;
                            MainMultiview.SetActiveView(View2);
                        }
                        else
                        {
                            lblMessage.BackColor = System.Drawing.Color.Yellow;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "No Data!";
                        }
                        break;
                    case 3:
                        if (myList2.Count > 0)
                        {
                            //GridView1.Visible = false;
                            //GridView2.Visible = false;
                            //GridView3.DataSource = myList2;
                            //GridView3.DataBind();
                            //GridView3.Visible = true;
                            MainMultiview.SetActiveView(View3);
                        }
                        else
                        {
                            lblMessage.BackColor = System.Drawing.Color.Yellow;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "No Data!";
                        }
                        break;
                    default:
                        break;
                }
            }
        }
