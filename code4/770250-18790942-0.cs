    foreach(DataRow dr in selectedPanels.Rows)
    {
    List<double> alluserpoints=new List<double>();
    if(userpoints.Rows.Count>1)
    {
    for(int i=0;i<userpoints.Rows.Count;i++)
    {
    alluserpoints.Add(Convert.ToDouble(dr["DistanceFromUserpoint"+i]));
    }
    dr["Closest_UserPoint"]=alluserpoints.Min().ToString();
    }
    else
    dr["Closest_UserPoint"]=dr["DistanceFromUserpoint0"];
    }
