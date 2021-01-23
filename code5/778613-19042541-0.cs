    private void InitPage()
        {
            string a1, b,a2,b2;
            _objSession = (ClsSession)Session["Login"];
            ds = _objSession._DataSet;
            dtAll = ds.Tables[3];
            dr = dtAll.NewRow();
           string str2 = (string)ViewState["str1"];
           if (str2 != null)
           {
               string[] str3 = str2.Split('~');
               a2 = str3[0];
               b2 = str3[1];
           }
           else
           {
               a2 = "a0";
               b2 = "b0";
           }
                str = (string)ViewState["str"];
            if (str == null)
            {
                a1 = "a0";
                b = "b";
            }
            else
            {
                string[] str1 = str.Split('~');
                a1 = str1[0];
                b = str1[1];
            }
            if (str==null)
            {
                for (int j = 0; j < dtAll.Rows.Count; j++)
                {
                    Table t = new Table();
                    TableRow r = new TableRow();
                    t.Rows.Add(r);
                    TableCell c = new TableCell();
                    lnkbtn = new LinkButton();
                    r.Cells.Add(c);
                    lnkbtn.Text = (j + 1).ToString();
                    lnkbtn.Visible = true;
                    lnkbtn.CommandName = "Test";
                    lnkbtn.CommandArgument = "Hi" + j;
                    lnkbtn.ID = "Hi" + j;
                    lnkbtn.ForeColor = Color.Blue;
                    lnkbtn.Width = 30;
                    lnkbtn.Font.Bold = true;
                    lnkbtn.Font.Size = 14;
                    lnkbtn.Font.Underline = false;
                    lnkbtn.Click += new EventHandler(lnkbtn_Click);
                    c.Controls.Add(lnkbtn);
                    plcHdrLinkButton.Controls.Add(lnkbtn);
    
                }
                ViewState["a"] = 0;
            }
           
            if (str2 != null)
            {
                string[] str3 = str2.Split('~');
                a2 = str3[0];
                a1 = a2;
            }
                    string resultString = Regex.Match(a1, @"\d+").Value;
                    int a = int.Parse(resultString);
                    ViewState["a"] = a;
                    plcHdrQuestion.Controls.Clear();
                    rb = new RadioButton();
                    rb.ID = "m" + a;
                    rb.AutoPostBack = true;
                    rb.GroupName = "a";
                    rb.Text = (a + 1) + "." + "&nbsp;&nbsp;&nbsp;" + dtAll.Rows[a][4].ToString();
                    CbxList = new CheckBoxList();
                    CbxList.ID = "Cbx" + a;
                    CbxList.Enabled = false;
                    CbxList.RepeatDirection = RepeatDirection.Horizontal;
                    CbxList.RepeatColumns = 2;
                    CbxList.CellPadding = 10;
                    CbxList.CellSpacing = 5;
                    CbxList.RepeatLayout = RepeatLayout.Table;
                    options = dtAll.Rows[a][5].ToString().Split('~');
                    plcHdrQuestion.Controls.Add(new LiteralControl("<br/>"));
                    for (int i = 0; i < options.Length; i++)
                    {
                        CbxList.Items.Add(new ListItem(options[i], options[i]));
                    }
                    plcHdrQuestion.Controls.Add(rb);
                    plcHdrQuestion.Controls.Add(CbxList);
                    rb.CheckedChanged += new EventHandler(lnkbtn_Click);
                    string st = (string)ViewState["str"];
                    ViewState["str1"] = st;
                    ViewState["str"] = null;
    
        }
    
    
        protected void lnkbtn_Click(object sender, EventArgs e)
        {
            Boolean _flag=true;
            ds = _objSession._DataSet;
            dt1 = ds.Tables[3];
            dr = dt1.NewRow();
            StringBuilder sb=new StringBuilder ();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Cbx = (RadioButton)plcHdrQuestion.FindControl("m" + i);
                Cbx1 = (CheckBoxList)plcHdrQuestion.FindControl("Cbx" + i);
                if (Cbx != null)
                {
                    if (Cbx.Checked == true)
                    {
                        Cbx1.Enabled = true;
                        _flag = false;
                        string st1 = (string)ViewState["st"];
                        string st="c";
                        if (st1 != null)
                            st = st1 + "~" + st;
                        ViewState["st"] = st;
                         st1 = (string)ViewState["st"];
                        sb.Append(st);
                    }
                    break;
                }
               
            }
            int count=(sb.ToString().Count());
            if (count>2)
            {
                _flag = true;
            }
            if ((lnkbtn.CommandName == "Test") && (_flag ==true))
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
    
                    lnkbtn = (LinkButton)plcHdrLinkButton.FindControl("Hi" + j);
                    string str = ((LinkButton)sender).CommandArgument;
    
                    lnkbtn.Enabled = true;
                    if (lnkbtn.ID == str)
                    {
                        ViewState["str"] = str + "~" + lnkbtn.ID;
                        InitPage();
                        ViewState["st"] = null;
                        _flag = false;
                        break;
                    }
                    
                }
    
            }
        }
