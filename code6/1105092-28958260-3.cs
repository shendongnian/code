    namespace DBModel.Models
    {
        public partial class Post
        {
            public int CommentsCount
            {
                get { return this.Comments.Count; }
            }
            ...
