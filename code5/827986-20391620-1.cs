    List<double> _data = new List<double>();
    foreach (DataRow row in dt.Rows)
    {
        _data.Add(DateTime.Now.GetUnixEpoch());
        _data.Add((double)Convert.ToDouble(row["S11"]));
    }
    JavaScriptSerializer jss = new JavaScriptSerializer();
    chartData = jss.Serialize(_data);
    Response.Write(chartData);
