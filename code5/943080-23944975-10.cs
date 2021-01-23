    public interface IBlogRepository
    {
        IEnumerable<Blog> Blogs(int pageNo, int pageSize);
        int TotalPosts();
    }
