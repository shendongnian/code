    public class CustomMapper : DapperExtensions.Mapper.ClassMapper<Photo>
    {
        public CustomMapper()
        {
            Map(x => x.PhotoId).Key(KeyType.Identity);
            Map(f => f.SomePropertyIDontCareAbout).Ignore();
            AutoMap();
        }
    }
