    public class Room
    {
        public string Name
        public double Size {get; set;}
        public int Quantity {get; set;}
        public double Amount {get; set;}
        public int Duration {get; set;}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)//this is so you can keep any data you want for the list
        {
            List<Room> rooms=new List<Room>();
            //then use the rooms.Add() to add the rooms you need.
            GridView1.DataSource=rooms
            GridView1.Databind()
        }
    }
