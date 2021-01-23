    public static IQueryable<Post> PostsWithTags(List<int> tagIds)
    {
            Context c = new Context();
            var Query = (from Group in c.TagRefs.GroupBy(g => g.TagId) let GroupTags = Group.Select(g => g.TagId) where tagIds.All(gt => GroupTags.Contains(gt)) select Group.Select(g => g.Post).FirstOrDefault());
            return Query ;
    }
