    public class Foo
    {
        public Foo()
        {
            this.Headshot = new Lazy<Image>( () => LoadHeadshotFromHDD );
        }
        public Lazy<Image> Headshot { get; set; }
    }
