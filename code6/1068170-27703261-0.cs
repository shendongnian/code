    public IEnumerable<ThreadInfoSubCategoryViewModel> ThreadInfoSubCategoryViewModel { get; set; }
    ...
    .ForMember(m => m.ThreadInfoSubCategoryViewModel, opt => opt.MapFrom(t =>
        t.Posts.Select(p => new ThreadInfoSubCategoryViewModel()
        {
            LastCommentBy = p.Author.UserName,
            DateOfLastPost = p.CreatedOn.ToString()
        })
    ))
