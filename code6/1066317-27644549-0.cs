    public JsonResult AgreementNo(string id)
    {
        string no;
        int intId = int.Parse(id);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT top(1) num from loan where id=@str", con);
        cmd.Parameters.AddWithValue("@str", intId);
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        no = ds.Tables[0].Rows[0]["num"].ToString();
        return Json(new
            {
             no = no
            }, JsonRequestBehavior.AllowGet);
        }
    }
