    internal sealed class Span
    {
        private readonly List<SpanPath> _spanList = new List<SpanPath>();
    
        public void Include(string path)
        {
            Check.NotEmpty(path, "path");
            SpanPath spanPath = new SpanPath(ParsePath(path));
            this.AddSpanPath(spanPath);
        }
    
        internal void AddSpanPath(SpanPath spanPath)
        {
            if (this.ValidateSpanPath(spanPath))
            {
                this.RemoveExistingSubPaths(spanPath);
                this._spanList.Add(spanPath);
            }
        }
        private bool ValidateSpanPath(SpanPath spanPath)
        {
            for (int i = 0; i < this._spanList.Count; i++) 
            {           
                if (spanPath.IsSubPath(this._spanList[i]))                
                   return false;    
            }
            
            return true;
        }
    }
