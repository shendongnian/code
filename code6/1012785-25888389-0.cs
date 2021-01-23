    StringBuilder sb=new StringBuilder();
    foreach(DataRow dr in dt.Rows)
    {
        object[] arr = dr.ItemArray;
        for (int i = 0; i < arr.Length; i++)
        {
             sb.Append(Convert.ToString(arr[i]));
             sb.Append("|");
        }
     }
    Response.Write(sb.ToString());
    
