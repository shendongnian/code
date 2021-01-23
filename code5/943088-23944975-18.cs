    public interface IBlogRepository
    {
        IEnumerable<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
    }
