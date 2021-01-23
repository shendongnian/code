    public void btn_Submit_Click(object sender, EventArgs e)
                {
                    Dictionary<string, Tuple<int, int>> d = new Dictionary<string, Tuple<int, int>>();
                int X_Co = 1;
                int Y_Co = 1;
                var t = new Tuple<int, int>(X_Co, Y_Co);
                d.Add("1", t);
    
                X_Co = 2;
                Y_Co = 2;
                t = new Tuple<int, int>(X_Co, Y_Co);
                d.Add("2", t);
        
                    List<Coordinate> cv = new List<Coordinate>();
        
                    foreach (KeyValuePair<string, Tuple<int, int>> entry in d)
                    {
                        Coordinate v = new Coordinate();
        
                        v.Date_Time = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss");
                        v.BeaconID = entry.Key;
                        v.X_Coordinate = entry.Value.Item1.ToString();
                        v.Y_Coordinate = entry.Value.Item2.ToString();
                        cv.Add(v);
                    }
                    SaveValues(cv);
                }
