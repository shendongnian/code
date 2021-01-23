            ListView lv = new ListView();
            lv.ItemTemplate = new DataTemplate(() =>
                {
                    Image image = new Image();
                    image.SetBinding(Image.SourceProperty, "Source");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Children = {
                                image, new Label{ Text = "Tubo"}
                            }
                        }
                    };
                });
            lv.ItemsSource = new Src[] { new Src(), new Src() };
            ...
    public class Src
    {
        public string Source { get; set; }
        public Src()
        {
            Source = "http://blog.rthand.com//images/Logo_vNext.png";
        }
    }
