    for (int i = 0; i < collection.Count; i++)
    {
        try
                {
                    obj.Emp_num = int.Parse(collection[i].Value);
                    obj.Req_ser = int.Parse(reqSer);
                    obj.Req_year = int.Parse(reqYear);
                    DataTable dt = Utilities.GetDep(obj.Emp_num);
                    obj.Main_code = int.Parse(dt.Rows[0]["dep_code"].ToString());
                    obj.Year = int.Parse(dt.Rows[0]["dep_year"].ToString());
                    obj.Dep_name = dt.Rows[0]["dep_name"].ToString();
                    string res = obj.InsertReward();//exception in case of repetition .
                    if (!string.IsNullOrEmpty(res))
                    {
                        div_detail_result.Visible = true;
                        SetMessage("");
                    }
                    else
                    {
                        SetMessage("Adding the employee has been done :" + collection[i].Text.Trim());
                    }
                }
        catch (Exception ee)
            {
                // your exception code
            }
    }
