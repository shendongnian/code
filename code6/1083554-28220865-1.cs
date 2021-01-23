    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public SetCoverPicture(Picture picture)
        {
            if(!Pictures.Contains(picture))
            {
                throw new ArgumentException("Picture is not in this Category");
            }
            var currentCoverPicture = Pictures.FirstOrDefault(p=p.IsCoverPicture == true);
            if(currentCoverPictur e!= null)
            {
                currentCoverPicture.IsCoverPicture = false;
            }
            picture.IsCoverPicture = true;
        }
    }
    public class Picture
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }
        public bool IsCoverPicture { get; protected internal set; }
    }
