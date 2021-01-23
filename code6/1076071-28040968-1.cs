    /// <summary>
    /// This class is used to extend the AlbumPicture object from the database
    /// </summary>
    /// <remarks>
    /// 2015-01-20: Created
    /// </remarks>
    public partial class AlbumPicture
    {
        /// <summary>An URL to the thumbnail.</summary> 
        public string Thumbnail
        {
            get
            {
                //ImageName is the actual image from the AlbumPicture object in the database
                if (string.IsNullOrEmpty(ImageName))
                {
                    return null;
                }
                return string.Format("/Thumbnail/{0}", ImageName);
            }
        }
    }
