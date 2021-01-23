    public class TagDatabase
    {
      //sniff...
     [ForeignKey("TagTypes")]
     public virtual int? TagTypeID { get; set; }      //Since TagTypes is optional, this should be nullable
     public virtual ICollection<TagTypesDb> TagTypes { get; set; }
     //sniff...
    }
