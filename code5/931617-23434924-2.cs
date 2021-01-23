    List<BlogViewModel> blogs = new List<BlogViewModel>();
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    CloudTable blogTable = tableClient.GetTableReference("BlogEntries");
    try
    {
        IEnumerable<BlogEntry> query = (from blog in blogTable.CreateQuery<BlogEntry>()
                                        select blog);
        foreach (BlogEntry blog in query)
        {
            blogs.Add(new BlogViewModel { Body = blog.Body });
        }
    }
    catch { }
