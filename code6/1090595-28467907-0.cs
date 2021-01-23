    public class CompoundType
    {
        public List<Photo> Photos { get; set; }
    }
    public ActionResult GetNewestPhotos()
    {
        CompoundType model = provider.GetPhotosFromDbAsCompoundObject();
        return PartialView("ViewName", model);
    }
