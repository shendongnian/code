    public class CategotiesEqualityComparer : IEqualityComparer<ac_Categories>
    {
        public bool Equals(ac_Categories x, ac_Categories y)
        {
            return x.ThumbnailAltText.Trim() == y.ThumbnailAltText.Trim();
        }
        public int GetHashCode(ac_Categories obj)
        {
            return obj.ThumbnailAltText.Trim().GetHashCode();
        }
    }
    List<ac_Categories> catlist = _db.ac_Categories
        .Where(c => c.VisibilityId == 0 && c.ThumbnailAltText != null
            && (!c.ThumbnailAltText.StartsWith("gifts/")
            && !c.ThumbnailAltText.StartsWith("email/")
            && !c.ThumbnailAltText.StartsWith("news/")
            && !c.ThumbnailAltText.StartsWith("promotions/")
            && !c.ThumbnailAltText.StartsWith("the-knowledge/")))
        .Distinct(new CategotiesEqualityComparer())
        .ToList()
