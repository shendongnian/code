    try
         {
               
                con.Open();
                da1.Fill(DS);
                grd_popup_details.DataSource = DS;
                string nextSty, currentSty;
                int psize;
                psize = grd_popup_details.PageSize;
               // MaxBindVal= Convert.ToInt32(hidMaxGridVal.Value);
                for (int i = psize; i < DS.Tables[0].Rows.Count; i++)
                {
                    currentSty = DS.Tables[0].Rows[(MaxBindVal) + i - 1]["STY_NBR"].ToString();
                    nextSty = DS.Tables[0].Rows[(MaxBindVal) + i]["STY_NBR"].ToString();
                    if (currentSty != nextSty)
                    {
                        grd_popup_details.PageSize = i;
                        MaxBindVal = MaxBindVal + i;
                        hidMaxGridVal.Value = MaxBindVal.ToString();
                        break;
                    }
                }
                grd_popup_details.AllowPaging = true;
                grd_popup_details.DataBind();
                con.Close();
            }
            catch (Exception es)
            {
                lblstatus.Text = es.Message.ToString();
    }
