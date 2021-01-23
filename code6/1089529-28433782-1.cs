    public void btn_Submit_Click(object sender, EventArgs e)
            {
                List<KeyValuePair<string, Tuple<int, int>>> d = new List<KeyValuePair<string, Tuple<int, int>>>
                {
                    new KeyValuePair<string, Tuple<int, int>>("1",Tuple.Create<int,int>(1,1)),
                    new KeyValuePair<string, Tuple<int, int>>("2",Tuple.Create<int,int>(2,2)),
                    new KeyValuePair<string, Tuple<int, int>>("3",Tuple.Create<int,int>(3,3)),
                    new KeyValuePair<string, Tuple<int, int>>("4",Tuple.Create<int,int>(4,4)),
                    new KeyValuePair<string, Tuple<int, int>>("5",Tuple.Create<int,int>(5,5))
                };
    
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
    
        public void SaveValues(List<Coordinate> v)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Coordinate>), new XmlRootAttribute("Coordinates"));
                    using (TextWriter textWriter = new StreamWriter(@"F:\Vista\Exporting into XML\Test1\Coordinates output.xml", true))
                    {
                        serializer.Serialize(textWriter, v);
                    }
                    MessageBox.Show("Coordinates were exported successfully", "Message");//Let the user know the export was succesfull            
                }
