    foreach (KeyValuePair<string, Tuple<int, int>> entry in d)
                {
                    List<Coordinate> cv = new List<Coordinate>();
                    Coordinate v = new Coordinate();
    
                    v.Date_Time = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss");
                    v.BeaconID = entry.Key;
                    v.X_Coordinate = entry.Value.Item1.ToString();
                    v.Y_Coordinate = entry.Value.Item2.ToString();
                    cv.Add(v);
                    SaveValues(cv);
                }
