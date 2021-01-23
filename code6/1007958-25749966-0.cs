    public class ListPostsQuery {
      private DbContext ctx;
      public ListPostsQuery( DbContext ctx ) {
         this.ctx = ctx;
      }
      public List<Post> Execute(int currentPage, int pageSize) {
       
         return ctx....
      }
    }
