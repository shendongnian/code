    protected void AjaxFileUpload1_UploadComplete(object sender,     AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        if(!Page.IsPostBack)
        {
          string c = System.IO.Path.GetFileName(e.FileName);
          string dpath = "~/Profile/Images/";
          string scn = txtSCN.Text;
          string line1 = txtLineitem.Text;
          string aging1 = txtAging.Text;             
          AjaxFileUpload1.SaveAs(MapPath(Path.Combine(dpath,c)));
          dpath = dpath + c;
          string str1 =  ConfigurationManager.ConnectionStrings["ProTracConnGMCH"].ConnectionString;
          SqlConnection cn = new SqlConnection(str1);
          cn.Open();
          string sql = "Update tbNoquoteFollowupupdate set MailreceivedURL = '" + dpath + "', chkMailreceived = 1 , Buyername =  '" + buyername + "'  where scn = '" + scn + "' AND lineItem = '" + line1 + "' and Aging ='" + aging1 + "' ";
          SqlCommand cmd = new SqlCommand(sql, cn);
          int i = cmd.ExecuteNonQuery();
          if (i > 0)
          {
            // AjaxFileUpload1.SaveAs(Path.Combine(dpath, e.FileName));
            //AjaxFileUpload1.SaveAs(MapPath(dpath));
          }
          cn.Close();
          BindGridviewData1();
          cn.Open();
          string cmd2 = "Insert Into tbMulitmailsreived (scn, lineItem,followupdate,  Aging,MailreceivedURL) Values ('" + scn + "', '" + line1 + "','" + DateTime.Now + "','" +  aging1 + "','" + dpath + "')";
          SqlCommand sqlCommand2 = new SqlCommand(cmd2, cn);
          sqlCommand2.ExecuteNonQuery();
          cn.Close();
       }
    }
