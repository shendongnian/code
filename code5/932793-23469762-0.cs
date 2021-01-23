    public class FaceT
    {
    	//your entity's other properties
    	public virtual IList<PhotoT> Photos { get; set; }
    	
    	public FaceT()
    	{
    		Photos = new List<PhotoT>();
    	}
    }
    
    public class FaceTMap : ClassMap<FaceT>
    {
    	public FaceTMap()
    	{
    		//mapping for other properties
            HasManyToMany(x => x.Photos)
                .Cascade.SaveUpdate()
    			.Inverse() //or Inverse on PhotoT
                .Table("FacePhotoT")
                .ParentKeyColumn("FaceID")
                .ChildKeyColumn("PhotoID");
    	}
    }
