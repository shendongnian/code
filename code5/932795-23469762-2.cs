    public class PhotoT
    {
    	//your entity's other properties here
    	public virtual IList<FaceT> Faces { get; set; }
    	
    	public PhotoT()
    	{
    		Faces = new List<FaceT>();
    	}
    }
    
    public class PhotoTMap : ClassMap<PhotoT>
    {
    	public PhotoTMap()
    	{
    		//mapping for other properties here
            HasManyToMany(x => x.Faces)
                .Cascade.SaveUpdate() //or another Cascade option of your choice
    			.Inverse() //or Inverse on FaceT
                .Table("FacePhotoT")
                .ParentKeyColumn("PhotoID")
                .ChildKeyColumn("FaceID");
    	}
    }
