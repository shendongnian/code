     protected void Page_Load(object sender, EventArgs e)
        {
        for (int i = 0; i < TotalNumberAdded; i++)
        {
            AddControls(i + 1);
        }
        for (int i = 0; i < TotalNumberSolAdded; i++)
        {
            AddMoreControls((i + 1), 1);
            DataTable dt = (DataTable)ViewState["t"];
            if (dt != null)
            {
                if ((TotalNumberSolAdded - dt.Rows.Count == 1) && (counter1 == dt.Rows.Count))
                {
                    break;
                }
                if (i != 0)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        int a1 = int.Parse(dt.Rows[k][0].ToString());
                        b = a1 + b;
                    }
                    start = b - int.Parse(dt.Rows[i][0].ToString());
                }
                else
                {
                    b = int.Parse(dt.Rows[i][0].ToString());
                    start = 0;
                }
                for (int j = start; j < b; j++)
                {
                    counter++;
                    AddMoreStepControls((j + 1), counter);
                }
                b = 0;
                counter = 0;
                counter1++;
            }
        }
    }
     private void AddControls(int controlNumber)
        {
        TextBox txtBoxSolution = new TextBox();
        Label lblSolution = new Label();
        txtBoxSolution.ID = "txtBoxSolution" + controlNumber;
        txtBoxSolution.TextMode = TextBoxMode.MultiLine;
        txtBoxSolution.Width = 470;
        txtBoxSolution.Height = 50;
        lblSolution.ID = "lblSolution" + controlNumber;
        lblSolution.Text = "Step " + (controlNumber + 1) + ": ";
        lblSolution.Width = 200;
       
        plcSolution.Controls.Add(lblSolution);
       
        plcSolution.Controls.Add(txtBoxSolution);
      
          }
     protected int TotalNumberAdded
        {
    
            get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
            set { ViewState["TotalNumberAdded"] = value; }
        }
    protected void btnAlternate_Click(object sender, EventArgs e)
        {
    
            Number = 0;
            lblSol.Text = "Solution 1";
            string str = (string)ViewState["btnId"];
            if (str != null)
            {
                btn = (Button)plcAddMoreSolution.FindControl(str);
                btn.Visible = false;
            }
            btnAdd.Visible = false;
            TotalNumberSolAdded++;
            AddMoreControls(TotalNumberSolAdded, 1);
            }
        protected int TotalNumberSolAdded
            {
                get { return (int)(ViewState["TotalNumberSolAdded"] ?? 0); }
                set { ViewState["TotalNumberSolAdded"] = value; }
            }
         private void AddMoreControls(int controlNumber, int n)
            {
    
            TextBox txtBoxMoreSolution = new TextBox();
            Label lblMoreSolution = new Label();
            btn = new Button();
            btn.Text = "add step";
            btn.ID = "btn" + controlNumber;
            btn.Click += new EventHandler(btn_Click);
            ViewState["btnId"] = btn.ID;
            Label lbl = new Label();
            lbl.Text = "Soltuion" + (controlNumber + 1);
            lbl.ID = "moreSolution" + (controlNumber + 1);
            lbl.Font.Size = 20;
            lbl.Font.Underline = true;
            lbl.Font.Bold = true;
            txtBoxMoreSolution.ID = "txtBoxMoreSolution" + controlNumber;
            txtBoxMoreSolution.TextMode = TextBoxMode.MultiLine;
    
            txtBoxMoreSolution.Width = 470;
            txtBoxMoreSolution.Height = 50;
            lblMoreSolution.ID = "lblMoreSolution" + controlNumber;
    
            lblMoreSolution.Text = "Step " + n + ": ";
            lblMoreSolution.Width = 200;
    
           
            plcAddMoreSolution.Controls.Add(lbl);
           
            plcAddMoreSolution.Controls.Add(lblMoreSolution);
         
            plcAddMoreSolution.Controls.Add(txtBoxMoreSolution);
          
            plcAddMoreSolution.Controls.Add(btn);
           
           
            }
        private void btn_Click(object sender, EventArgs e)
            {
                TotalNumberSolStepAdded++;
                Number++;
                string str = (string)ViewState["btnId"];
                if (str != null)
            {
                string resultString = Regex.Match(str, @"\d+").Value;
                a = int.Parse(resultString);
                table = (DataTable)ViewState["t"];
                if (table == null)
                {
                    DataTable table1 = new DataTable();
                    table1.Columns.Add("count", typeof(int));
                    dr = table1.NewRow();
                    table1.Rows.Add(dr);
                    table1.Rows[a - 1]["count"] = Number;
                    table1.AcceptChanges();
                    ViewState["t"] = table1;
                }
                else
                {
                    if (a != table.Rows.Count)
                    {
                        dr = table.NewRow();
                        table.Rows.Add(dr);
                    }
                    table.Rows[a - 1]["count"] = Number;
                    table.AcceptChanges();
                    ViewState["t"] = table;
                }
            }
    
    
            AddMoreStepControls(TotalNumberSolStepAdded, Number);
        }
     protected int TotalNumberSolStepAdded
        {
            get { return (int)(ViewState["TotalNumberSolStepAdded"] ?? 0); }
            set { ViewState["TotalNumberSolStepAdded"] = value; }
        }
    
        protected int Number
        {
            get { return (int)(ViewState["Number"] ?? 0); }
            set { ViewState["Number"] = value; }
        }
    
        private void AddMoreStepControls(int controlNumber, int counter)
        {
    
            TextBox txtBoxMoreStepSolution = new TextBox();
            Label lblMoreStepSolution = new Label();
    
            txtBoxMoreStepSolution.ID = "txtBoxMoreStepSolution" + controlNumber;
            txtBoxMoreStepSolution.TextMode = TextBoxMode.MultiLine;
    
            txtBoxMoreStepSolution.Width = 470;
            txtBoxMoreStepSolution.Height = 50;
            lblMoreStepSolution.ID = "lblMoreStepSolution" + controlNumber;
    
            lblMoreStepSolution.Text = "Step " + (counter + 1) + ": ";
            lblMoreStepSolution.Width = 200;
    
          
            plcAddMoreSolution.Controls.Add(lblMoreStepSolution);
           
            plcAddMoreSolution.Controls.Add(txtBoxMoreStepSolution);
         
    
           
    
        }
