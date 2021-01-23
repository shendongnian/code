    //string datasource
        List<string> strList = null;
        //suggestion listbox
        ListBox sugBox = null;
        public FrmTextSuggest()
        {
            InitializeComponent();
            //setting the textbox control
            strList = new List<string>()
            {
                "USA",
                "England",
                "China",
                "Japan",
                "Korea",
                "India",
                "France",
                "Canada"
            };
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(strList.ToArray());
            this.txtCountry.AutoCompleteCustomSource = autoCollection;
            this.txtCountry.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtCountry.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //register the Down Arrow Key event
            this.txtCountry.KeyDown += new KeyEventHandler(txtCountry_KeyDown);
        }
        void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            //show the your own suggestion box when pressing down arrow and the text box is empty
            if (e.KeyCode == Keys.Down && txtCountry.Text.Trim().Equals(""))
            {
                sugBox = new ListBox();
                //define the box
                sugBox.Width = txtCountry.Width;
                Point p = txtCountry.Location;
                p.Y += txtCountry.Height;
                sugBox.Location = p;
                sugBox.Items.AddRange(strList.ToArray());
                //copy the value to the textbox when selected index changed.
                sugBox.SelectedIndexChanged += new EventHandler(sugBox_SelectedIndexChanged);
                //show box
                if (sugBox.Items.Count > 0)
                {
                    sugBox.SelectedIndex = 0;
                    this.Controls.Add(sugBox);
                    sugBox.Focus();
                }
            }
            //remove and hide your own suggestion box when other operation
            else
            {
                if (sugBox != null && this.Controls.Contains(sugBox))
                {
                    this.Controls.Remove(sugBox);
                    sugBox.Dispose();
                    sugBox = null;
                }
            }
        }
        void sugBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selText = this.sugBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selText))
            {
                this.txtCountry.Text = selText;
            }
        }
