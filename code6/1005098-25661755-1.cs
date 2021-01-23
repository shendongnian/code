    protected void Page_Load(object sender, EventArgs e)
        {
            accountInfo_Ref.IaccountInfoSrvcClient accInfoClient = new    accountInfo_Ref.IaccountInfoSrvcClient();
            
            int id = (int)Session["UserId"];
            List<string> rows = new List<string>(accInfoClient.getAccountInfo(id));
            // display the first row
            string row = rows.FirstOrDefault();
            if (String.IsNullOrEmpty(row))
            {
               // record cannot be found
            }
            else
            {
                string[] details = row.Split(';');
          
                id_lbl.Text = details[0];
                order_id_lbl.Text = details[1];
            }
        }
