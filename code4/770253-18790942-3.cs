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
    if(alluserpoints.Count>0)
    dr["Closest_UserPoint"] = alluserpoints.Min().ToString()+"+userpoint"+i;  
    else
    dr["Closest_UserPoint"] ="none";                        
    }
    }
    else
    {
    foreach(DataRow dr in selectedPanels.Rows)
    {
    if(Convert.ToDouble(userpoints.Rows[0].radius>Convert.ToDouble(dr["DistanceFromUserpoint0"])
    {
    dr["Closest_UserPoint"]=dr["DistanceFromUserpoint0"]+"+userpoint0";
    }
    else
    {
    dr["Closest_UserPoint"]="none";
    }
    }
    }
