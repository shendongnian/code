    public class SData 
    {
        public SDataCollection ParentCollection { get; set; }
    }
    
    
    public class SDataCollection : CollectionBase
    {
        public int Add(SData sDataItem)
        {
            if (sDataItem != null)
            {
                sDataItem.ParentCollection = this;
                return this.List.Add(sDataItem);
            }
            return -1;
        }
    }
