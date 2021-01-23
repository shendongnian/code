    /// <summary>
    /// my own data define
    /// </summary>
    public class MyFloor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        //very important, the result will be displayed in the combox
        public override string ToString()
        {
            return string.Format("{0}->{1}->{2}", ID, Name, Floor);
        }
    }
