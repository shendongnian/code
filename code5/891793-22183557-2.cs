    internal sealed class TwoListsForm : Form
    {
        private sealed class ListItem : IComparable<ListItem>
        {
            public int Id;
            public string Name;
            public int CompareTo(ListItem other)
            {
                return other == null ? 1 : Id.CompareTo(other.Id);
            }
            public override string ToString()
            {
                return Name;
            }
        }
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnToLeft;
        public TwoListsForm()
        {
            InitializeComponent();
        }
        public TwoListsForm(string ht)
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Basketball;Integrated Security=True;User ID=apo;Password=nia2"))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT PLAYERS.ID, PLAYERS.NO, PLAYERS.SURNAME, PLAYERS.FIRSTNAME, CAST(PLAYERS.NO AS VARCHAR) + ' - ' + PLAYERS.SURNAME + ', ' + PLAYERS.FIRSTNAME AS PLAYER FROM PLAYERS INNER JOIN TEAMS ON PLAYERS.TEAM_ID = TEAMS.ID WHERE (TEAMS.NAME ='" + ht + "')ORDER BY PLAYERS.NO", con))
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    object[] items = new object[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                        items[i] = new ListItem { Id = (int)dt.Rows[i]["ID"], Name = dt.Rows[i]["PLAYER"].ToString() };
                    lstLeft.Items.AddRange(items);
                }
                con.Close();
            }
        }
        private void InitializeComponent()
        {
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstLeft
            // 
            this.lstLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.Location = new System.Drawing.Point(12, 12);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLeft.Size = new System.Drawing.Size(242, 264);
            this.lstLeft.Sorted = true;
            this.lstLeft.TabIndex = 0;
            // 
            // lstRight
            // 
            this.lstRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.Location = new System.Drawing.Point(341, 12);
            this.lstRight.Name = "lstRight";
            this.lstRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRight.Size = new System.Drawing.Size(242, 264);
            this.lstRight.Sorted = true;
            this.lstRight.TabIndex = 1;
            // 
            // btnToRight
            // 
            this.btnToRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToRight.Location = new System.Drawing.Point(260, 77);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(75, 23);
            this.btnToRight.TabIndex = 2;
            this.btnToRight.Text = ">>>";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToLeft.Location = new System.Drawing.Point(260, 180);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(75, 23);
            this.btnToLeft.TabIndex = 3;
            this.btnToLeft.Text = "<<<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // TwoListsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 290);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.lstRight);
            this.Controls.Add(this.lstLeft);
            this.Name = "TwoListsForm";
            this.Text = "Two Lists Form";
            this.ResumeLayout(false);
        }
        private void btnToRight_Click(object sender, EventArgs e)
        {
            moveItems(lstLeft, lstRight);
        }
        private void btnToLeft_Click(object sender, EventArgs e)
        {
            moveItems(lstRight, lstLeft);
        }
        private void moveItems(ListBox from, ListBox to)
        {
            if (from.SelectedItems.Count == 0)
            {
                MessageBox.Show("Empty selection");
                return;
            }
            object[] tmp = new object[from.SelectedItems.Count];
            from.SelectedItems.CopyTo(tmp, 0);
            to.Items.AddRange(tmp);
            from.BeginUpdate();
            foreach (var item in tmp)
                from.Items.Remove(item);
            from.EndUpdate();
        }
    }
