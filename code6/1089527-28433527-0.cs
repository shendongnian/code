    public class Coordinates
    {
        public Coordinate[] Coordinate;
    }
    public void btn_Submit_Click(object sender, EventArgs e)
    {
        List<Coordinate> lstCoordinates = new List<Coordinate>();
        foreach (KeyValuePair<string, Tuple<int, int>> entry in d)
        {
            Coordinate v = new Coordinate();
            v.Date_Time = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss");
            v.BeaconID = entry.Key;
            v.X_Coordinate = entry.Value.Item1.ToString();
            v.Y_Coordinate = entry.Value.Item2.ToString();
            lstCoordinates.Add(v);
        }
        Coordinates cdCol = new Coordinates();
        cdCol.Coordinate = lstCoordinates.ToArray();
        SaveValues(cdCol);
    }
    public void SaveValues(Coordinates v)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Coordinates));
        using (TextWriter textWriter = new StreamWriter(@"F:\Vista\Exporting into XML\Test1\Coordinates output.xml", true))
        {
            serializer.Serialize(textWriter, v);
        }
        MessageBox.Show("Coordinates were exported successfully", "Message");//Let the user know the export was succesfull            
    }
