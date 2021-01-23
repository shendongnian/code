    public IAsyncDocumentSession Session { get; set; }
            
            public async override Task<HttpResponseMessage> ExecuteAsync(
                HttpControllerContext controllerContext, CancellationToken cancellationToken)
            {
                using (Session = WebApiApplication.Store.OpenAsyncSession())
                {
                    var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                    await Session.SaveChangesAsync();
    
                    return result;
                }
            }
