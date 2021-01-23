    if (userpoints.Rows.Count > 1)
    {
    foreach (DataRow dr in selectedPanels.Rows)
    {
    List<double> alluserpoints = new List<double>();             
    for (int i = 0; i < userpoints.Rows.Count; i++)
    {
    if (Convert.ToDouble(userpoints.Rows[i].radius) > Convert.ToDouble(dr["DistanceFromUserpoint" + i]))
    {
        alluserpoints.Add(Convert.ToDouble(dr["DistanceFromUserpoint" + i]));
    }
    }
    dr["Closest_UserPoint"] = alluserpoints.Min().ToString();                              
    }
    }
    else
    {
    foreach(DataRow dr in selectedPanels.Rows)
    {
    dr["Closest_UserPoint"]=Convert.ToDouble(dr["DistanceFromUserpoint0"];
    }
    }
