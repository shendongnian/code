    public class Song
    {
        public string Title;
        public string Path;
        public override string ToString()
        {
            return Title;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Song)
                return this.Path.Equals(((Song)obj).Path);
            else
                return base.Equals(obj);
        }
    }
