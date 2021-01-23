    public IQueryable<MembersForumProperties> RepliesToForumPost(int postId)
    {
        using (MyContext db = new MyContext())
        {
            return db.MembersForum.Where(c => c.PostId == postId).AsQueryable();
        }
    }
