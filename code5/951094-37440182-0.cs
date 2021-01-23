     public Category()
        {
            this.Posts = new HashSet<Post>();
         
        }
     public virtual ICollection<Post> Posts { get; set; }
