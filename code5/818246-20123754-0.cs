    [JsonObject(MemberSerialization.OptIn)]
    public class LeafClass : MainClass
    {
        [JsonProperty]
    	public string ID2
    	{
    		get;
    		set;
    	}
    	
    	#region Constructor
    	public LeafClass(MainClass oMainClass)
    	{
    		this.ID = oMainClass.ID;
    		this.ID2 = "my 2nd ID";
    	}
    	#endregion
    }
