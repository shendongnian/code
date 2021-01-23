     public class Article
            {
                public List<string> ImagePath = new List<string>();
                public string Subject;
                public string Words;
                public BitmapImage BindImage
                {
                    get;
                    set
                    {
                        if (ImagePath.Any())
                            value = new BitmapImage(new Uri(ImagePath.FirstOrDefault(), UriKind.Relative));
                    }
                }
            }
