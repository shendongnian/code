      public class Article
                {
                    public List<string> ImagePath = new List<string>();
                    public string Subject;
                    public string Words;
                    BitmapImage _image;
                    public BitmapImage BindImage
                    {
                       **Edits**
                        get{
                            return _image ;
                           }
                        set
                        {
                            if (ImagePath.Any())
                               {
                                value = new BitmapImage(new Uri(ImagePath.FirstOrDefault(), UriKind.Relative));
                             _image = value;
                               }
                        }
                    }
                }
