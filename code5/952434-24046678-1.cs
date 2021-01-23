    using System.Linq;
    using System.Data.Entity;
    public class Class1
    {
    	public Class1()
    	{
            var website = _repository
                .Websites
                .Include(c => c.SourceUrls.ContentTypes.Distinct())
                .Where(w => w.UserId == userId && w.WebsiteGuidArg == websiteGuidArg);
    	}
    }
