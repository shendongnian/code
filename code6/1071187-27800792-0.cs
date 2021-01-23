	public IDataFieldBuilder<IDALModel> Embed<T>() where T : IDALModel
    {
		IDataFieldBuilder<IDALModel> returnObject = (IDataFieldBuilder<IDALModel>)new DataFieldBuilder<T>();
        return returnObject;
    }
	
	interface IDALModel {}
	
	class AddressModel : IDALModel 
	{
	    public int AddressId {get;set;}
	    public string Address {get;set;}
	}
	
	class AccountModel : IDALModel
	{
	    public int AccountId {get;set;}
	    public string Name {get;set;}
	}
	
	class DataFieldBuilder<T> : IDataFieldBuilder<T>
	{
		
	}
	
	interface IDataFieldBuilder<out T>
	{
		
	}
