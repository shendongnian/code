       protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Populate();
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Populate();
        }
        void Populate()
        {
            PlaceHolder1.Controls.Clear();
            PlaceHolder2.Controls.Clear();
            PlaceHolder3.Controls.Clear();
            PlaceHolder4.Controls.Clear();
            PlaceHolder5.Controls.Clear();
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                int a = int.Parse(TextBox1.Text);
                for (int j = 1; j <= a; j++)
                {
                    Guid IDUnik = new Guid();
                    artikulli = new DropDownList();
                    cmimi = new TextBox();
                    tregoCmimi = new Label();
                    sasia = new TextBox();
                    cmimiGjithsej = new Label();
                    artikulli.ID = j.ToString(IDUnik.ToString("N").Substring(31));
                    artikulli.AutoPostBack = true;
                    cmimi.ID = j.ToString(IDUnik.ToString("D").Substring(30));
                    tregoCmimi.ID = j.ToString(IDUnik.ToString("P"));
                    sasia.ID = j.ToString(j.ToString(IDUnik.ToString("X")));
                    cmimiGjithsej.ID = j.ToString(j.ToString(IDUnik.ToString("B"))); ;
                    PlaceHolder1.Controls.Add(artikulli);
                    PlaceHolder2.Controls.Add(cmimi);
                    PlaceHolder3.Controls.Add(tregoCmimi);
                    PlaceHolder4.Controls.Add(sasia);
                    PlaceHolder5.Controls.Add(cmimiGjithsej);
                    artikulli.Items.Insert(0, new ListItem("<Select Subject>", "0"));
                    artikulli.Items.Insert(1, new ListItem("<Select Subject>", "1"));
                }
            }
        }
