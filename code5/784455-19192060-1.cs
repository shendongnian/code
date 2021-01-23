        public partial class UserComments : System.Web.UI.UserControl
        {
            public List<CallReview> Comments;
        
            public void BindComments()
            {
                commentsRepeater.DataSource = Comments;
                commentsRepeater.DataBind();
            }
        }
