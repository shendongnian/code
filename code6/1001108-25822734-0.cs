    static void Main(string[] args)
    {
        var sessionStore = new EmbeddableDocumentStore
        {
            RunInMemory = true,
            UseEmbeddedHttpServer = true,
            Conventions =
            {
                DefaultQueryingConsistency = ConsistencyOptions.AlwaysWaitForNonStaleResultsAsOfLastWrite
            }
        };
        sessionStore.Initialize();
        using (var session = sessionStore.OpenSession())
        {
            var allTags = new[] {"C#", ".net", "RavenDB", "Linux", "Mac"};
            var tagsCollection = new[] {"C#", ".net", "RavenDB"};
            var complementTagsCollection = allTags.Except(tagsCollection).ToList();
                
            session.Store(new Post
            {
                Tags = new List<string>{"C#",".net"}
            });
            session.SaveChanges();
            // Posts where all their tags are in tagsCollection
            var result = session.Query<Post>().Where(x => !x.Tags.In(complementTagsCollection)).ToList();
        }
    }
