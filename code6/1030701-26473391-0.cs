     public class DecoratedContentLoader : IContentLoader
     {        
         IContentLoader c;
         IPageSecurity p;
         public DecoratedContentLoader(IContentLoader c, IPageSecurity p)
         {
             this.c = c;
             this.p = p;           
         }
         public T LoadItem<T>(Guid id) where T : Page
         {
             var page = c.LoadItem<T>( id );
             if ( p.CanUserReadPage( p ) )
                return p;
             // throw or return null
         }
     }
