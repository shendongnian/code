    public interface IComments : IDisposable
    {
        IQueryable<comments> GetPostComments(int postid);
        //void Add(comments comment);
        //void Update(comments comment);
        //void Remove(int id);
    }
    public partial class comments
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Author { get; set; }
        public Nullable<System.DateTime> Posted { get; set; }
        public Nullable<int> PostID { get; set; }
        public virtual blog_post blog_post { get; set; }
    }
