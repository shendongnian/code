    public class LazyLoadingBlog
    {
        private ICollection<Post> _Posts = new List<Post>();
    
        public virtual ICollection<Post> Posts 
        { 
           get { return _Posts ; }
           //protected set lets EF override for lazy loading
           protected set { _Posts = value; 
        }
    } 
