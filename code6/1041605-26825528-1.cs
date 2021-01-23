    class NameComparer : IComparer<String> {
        public Int32 Compare(String x, String y) {
            // put Name comparison logic here
        }
    }
    
    IEnumerable<TItem> sorted = propertyList.OrderBy( x => x.Name, new NameComparer() );
