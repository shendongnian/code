    public class Imagem
    {
        public string path { get; set; }
        public string page { get; set; }
        public int id { get; set; }
        public BitmapImage ImageSource{get;set;}
    }
    
    not1.img = new Imagem() { path = "Assets/pipa.png", page = "Noticias", id = 1 , ImageSource = new BitmapImage(new Uri("Assets/pipa.png",UriKind.Relative)) };
    
    <Image Name="NewsImg" Source="{Binding img.ImageSource}" Stretch="Fill" Grid.Column="0"/>
