    public interface ICommentRecord
    {
        int Id { get; }
        // Expose any other public members you want
    }
    public class Comments
    {
        private static List<CommentRecord> Records = new List<CommentRecord>();
        static Comments()
        {
            LoadFromDatabase();
        }
        public static void LoadFromDatabase()
        {
            // load and loop to fill data...
            CommentRecord comment = new CommentRecord();
            comment.Id = 2;
            Records.Add(comment);
        }
        // Make this returnn the public interface
        public static ICommentRecord FindById(Int32 id)
        {
            return Records.Find(delegate(CommentRecord x) { return x.Id == id; });
        }
        // Make this class private to Comments class. So its only accessible from within Comments
        private class CommentRecord : ICommentRecord
        {
            public int Id { get; internal set; }  
        }
    }
