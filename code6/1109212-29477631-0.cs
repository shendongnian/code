    // Add first DbContext here
    AddEntityFramework(Configuration)
      .AddSqlServer()
      .AddDbContext<ApplicationDbContext>();
    // Add second DbContext here
    AddEntityFramework(Configuration)
     .AddInMemoryStore()
     .AddDbContext<WorkModel>(options => { options.UseInMemoryStore(persist: true); });
