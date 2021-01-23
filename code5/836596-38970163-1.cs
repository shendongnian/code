    public List<Dictionary<string, string>> GetProducts()
    {
        DataTable dtTable = loadProduct();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        List<Dictionary<string, string>> plist = new List<Dictionary<string, string>>();
                    foreach (DataRow dr in dtTable.Rows)
                    {
                        
                        dic.Add(dr[0].ToString(), dr[1].ToString());
                       
                    }
                     plist.Add(dic);
                    return plist;
    }
