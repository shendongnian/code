    string sql = "create table Polygons (PolygonId int, PointId int, X double, Y double)";
    
    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
      {
         command.ExecuteNonQuery();
      }
    
    int pointId = 1;
    
    for (int i = 0; i < listOfCustomPolygons.Count; i++)
      for (int j = 0; j < listOfCustomPolygons[i].listOfVertexes.Count; j++)
        {
           string strSQL = "INSERT INTO Polygons (PolygonId,PointId,X,Y) Values (@polyID, @PointID, @X, @Y);";
    
           using (SQLiteCommand insertCommand = new SQLiteCommand(strSQL, m_dbConnection))
           {
             insertCommand.Parameters.Add(new SQLiteParameter("@polyID")).Value = i+1;
             insertCommand.Parameters.Add(new SQLiteParameter("@PointID")).Value = pointId++;
             insertCommand.Parameters.Add(new SQLiteParameter("@X")).Value = listOfCustomPolygons[i].listOfVertexes[j].X;
             insertCommand.Parameters.Add(new SQLiteParameter("@Y")).Value = listOfCustomPolygons[i].listOfVertexes[j].Y;
             
             insertCommand.ExecuteNonQuery();
           }
        }
