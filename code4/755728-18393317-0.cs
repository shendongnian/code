    public class MyCustomModel
    {
        public MyCustomModel()
        {
            MyList = new List<PrmTbl_Level>();
            MyItemToCreate = new PrmTbl_Level();
        }
    
        public List<PrmTbl_Level> MyList { get; set; }
        public PrmTbl_Level MyItemToCreate { get; set; }
    }
