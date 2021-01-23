    public class ImageMap 
    {
        // the <composite-element> as IComponentElement<>
        // will replace the above mapper
        // public static Action<IComponentMapper<Image>> Mapping()
        public static Action<IComponentElementMapper<Image>> Mapping()
        {
            return c =>
                {
                    c.Property(p => p.AltText);
                    c.Property(p => p.Name, m => 
                    {
                        m.Length(255);
                    });
                    c.Property(p => p.Path, m =>
                    {
                        m.Length(255);
                    });
                    c.Property(p => p.Height);
                    c.Property(p => p.Width);
                    c.Parent(x => x.Article, p => p.Access(Accessor.ReadOnly));                    
                };
        }
    }
