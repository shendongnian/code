        public Int32 Id { get; set; }
        public string EmpName { get; set; }
        public string Add { get; set; }
       
       private void frm2_Load(object sender, EventArgs e)
       {
               TxtId.Text = Id.ToString();
               TxtName.Text =EmpName;
               TxtAdd.Text = Add;
        }
