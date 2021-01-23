    internal class Coordinate
    {
        public int coordID { get; set; }                // This is your CheckpointID
        public string Location { get; set; }            // This is the string coordinate loaded 
        public DateTime TimeStamp { get; set; }         // This is the TimeStamp of the coordinate
    }
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Coordinate> Coordinates {get;set;}
    }
