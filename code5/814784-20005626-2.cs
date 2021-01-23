    public class PostModel
    {
        public int ID { get; set; }
        public int SomeOtherID { get; set; }
    }
    [HttpPost]
    public void SomeAction(PostModel postModel)
    {
        //do something with postModel.ID and postModel.SomeOtherID
    }
