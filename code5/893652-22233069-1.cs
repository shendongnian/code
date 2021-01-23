    public class Photo
    {
        // ...
        public void AddTag(Tag tagToAdd)
        {
            this.Tags.Add(new Tag_Photo_XREF { Tag = tagToAdd });
        }
        
        // ...
     }
