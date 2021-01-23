    public class ImageUpload
    {
            public int ID { get; set; }       
    
            public string Title { get; set; }
    
            public string Description { get; set; }       
    
            [AllowHtml]       
            public string Contents { get; set; }
    
            public byte[] Image { get; set; }
    }
    
    public ActionResult Create()
    {
         return View();
    }
    
    @using (Html.BeginForm("Create","Content", FormMethod.Post, new { enctype ="multipart/form-data" }))
    { 
       <input type="file" name="ImageData" id="ImageData" onchange="fileCheck(this);" />
    }
    
    [Route("Create")]
    [HttpPost]
    public ActionResult Create(ImageUpload model)
    {
        HttpPostedFileBase file = Request.Files["ImageData"];
    
        ContentRepository service = new ContentRepository();
    
        int i = service.UploadImageInDataBase(file, model);
    
        if (i == 1)
        {
             return RedirectToAction("Index");
        }
    
        return View(model);
    }
    
    private readonly ImageDBContext db = new ImageDBContext();
    
    public int UploadImageInDataBase(HttpPostedFileBase file, ImageUplad imageupload)
    {
            ImageUpload.Image = ConvertToBytes(file);
            var Content = new Content
            {
                Title = imageupload.Title,
                Description = imageupload.Description,
                Contents = imageupload.Contents,
                Image = imageupload.Image
            };
    
            db.Contents.Add(Content);
    
            int i = db.SaveChanges();
    
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
    }
    
    public byte[] ConvertToBytes(HttpPostedFileBase image)
    {
        byte[] imageBytes = null;
    
        BinaryReader reader = new BinaryReader(image.InputStream);
    
        imageBytes = reader.ReadBytes((int)image.ContentLength);
    
        return imageBytes;
    }
    
    Step 6: Display an image form database on view. Here we display the content and image from the database.
    
    public ActionResult Index()
    {
        var content = db.Contents.Select(s => new
        {
            s.ID,
            s.Title,
            s.Image,
            s.Contents,    
            s.Description    
          });
    
          List<ImageUpload> imageModel = content.Select(item => new ImageUpload()    
          {    
                ID = item.ID,    
                Title = item.Title,    
                Image = item.Image,    
                Description = item.Description,    
                Contents = item.Contents    
            }).ToList();
           return View(imageModel);    
     }
    
    <td>
         <img src="/Content/RetrieveImage/@item.ID" alt="" height=100 width=200 />
    </td>
    
    public ActionResult RetrieveImage(int id)
    {
        byte[] cover = GetImageFromDataBase(id);
    
        if (cover != null)
        {
            return File(cover, "image/jpg");
        }
        else
        {
            return null;
        }
    }
    
    public byte[] GetImageFromDataBase(int Id)
    {
        var q = from temp in db.Contents where temp.ID == Id select temp.Image;
    
        byte[] cover = q.First();
    
        return cover;
    }
