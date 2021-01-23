     public class InsertRequestDetail : System.Web.Services.WebService
    {
        [ScriptMethod(UseHttpGet = true)]
        [WebMethod]
        public List<RequestResponse> InsertDetail(List<string> d)
        {
            List<RequestResponse> list = new List<RequestResponse>();
            string prhid = d[0];
            string item = d[1];
            string Quantity = d[2];
            string Price = d[3];
            string Make = d[4];
            string Discription = d[5];
            Pro_DbCon obj2 = new Pro_DbCon();
            string constr = obj2.dbconnection();
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string select = "Select * From Pro_Detail where PRHId = @prhid AND Item = @item AND Quantity = @quantity AND Price = @price AND Make = @make AND Discription = @dis";
                SqlCommand cmd1 = new SqlCommand(select, con);
                cmd1.Parameters.AddWithValue("@prhid", prhid);
                cmd1.Parameters.AddWithValue("@item", item);
                cmd1.Parameters.AddWithValue("@quantity", Quantity);
                cmd1.Parameters.AddWithValue("@price", Price);
                cmd1.Parameters.AddWithValue("@make", Make);
                cmd1.Parameters.AddWithValue("@dis", Discription);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    RequestResponse r = new RequestResponse();
                    r.status = false;
                    r.msg = "Duplicate";
                    list.Add(r);
                }
                else
                {
                    dr.Close();
                    string insertquery = "Insert into Pro_Detail (PRHId,Item,Quantity,Price,Make,Discription ) values (@prhid,@item,@quantity,@price,@make,@dis)";
                    SqlCommand cmd = new SqlCommand(insertquery, con);
                    cmd1.Parameters.AddWithValue("@prhid", prhid);
                    cmd1.Parameters.AddWithValue("@item", item);
                    cmd1.Parameters.AddWithValue("@quantity", Quantity);
                    cmd1.Parameters.AddWithValue("@price", Price);
                    cmd1.Parameters.AddWithValue("@make", Make);
                    cmd1.Parameters.AddWithValue("@dis", Discription);
                    int affectedrows = cmd.ExecuteNonQuery();
                    if (affectedrows > 0)
                    {
                        RequestResponse r = new RequestResponse();
                        r.status = true;
                        r.msg = "success";
                        list.Add(r);
                    }
                    else
                    {
                        RequestResponse r = new RequestResponse();
                        r.status = false;
                        r.msg = "error on adding";
                        list.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                RequestResponse r = new RequestResponse();
                r.status = false;
                r.msg = "Error !" + ex.ToString();
                list.Add(r);
            }
            finally
            {
                con.Close();
            }
            
            return list;
        }
    }
