    Tag t= null;
    TagView tv = null;
    tags = _session.QueryOver(() => t)
                   .Left.JoinQueryOver(() => t.Articles, () => a)
                   .SelectList(list => list
                                           .SelectGroup(() => t.Id).WithAlias(() => tv.Id)
                                           .SelectGroup(() => t.Name).WithAlias(() => tv.Name)
                                           .SelectGroup(() => t.CreatedBy).WithAlias(() => tv.CreatedBy)
                                           .SelectGroup(() => t.CreatedDate).WithAlias(() => tv.CreatedDate)
                                           .SelectGroup(() => t.LastModifiedBy).WithAlias(() => tv.LastModifiedBy)
                                           .SelectGroup(() => t.LastModifiedDate).WithAlias(() => tv.LastModifiedDate)
                                           .SelectCount(() => t.Articles).WithAlias(() => tv.ArticlesCount))
                   .TransformUsing(Transformers.AliasToBean<TagView>())
                   .List<TagView>();
