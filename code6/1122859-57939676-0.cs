public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    ...
    
    app.UseMvc(b =>
    {
        b.MapODataServiceRoute("odata", "odata/{customerName}", GetEdmModel());
    });
}
Example controller (_note `customerName` parameter on the action_):
public class BooksController : ODataController
{
    private IContextResolver _contextResolver;
    public BooksController(IContextResolver contextResolver)
    {
        _contextResolver = contextResolver;
    }
    [EnableQuery]
    public IActionResult Get(string customerName)
    {
        var context = _contextResolver.Resolve(customerName);
        return Ok(context.Books);
    }
}
Then you can hit the URL like: `https://localhost/odata/acmecorp/Books`
