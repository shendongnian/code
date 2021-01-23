        protected void Page_Load(object sender, Eventargs e)
        {
            string ID_sel = "SELECT TOP 1 ID FROM table ORDER BY ID DESC";
            SqlConnection IDcon = new SqlConnection(Connection string);
            SqlCommand cmdsel = new SqlCommand(ID_sel, IDcon);
            IDcon.Open();
            SqlDataReader read = cmdsel.ExecuteReader();
            
            read.Read();
            string a = read["ID"].ToString();
                    
            TextboxID.Text = ();
            for (int i = 0; i < 1; i++)
            {
                string val = a.Substring(1, a.Length - 1);
                int newnumber = Convert.ToInt32(val) + 1;
                a = "B" + newnumber.ToString("000000");
            {
            TextBoxID.Text = a;
            IDcon.Close;
