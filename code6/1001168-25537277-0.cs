    void Main()
    {
    	AutoMapper.Mapper.CreateMap<UserModel, UserViewModel>().ConvertUsing(new UserModelToUserViewModelConverter());
    	AutoMapper.Mapper.AssertConfigurationIsValid();
    
    	var userModel = new UserModel
    	{
    		DifferentPropertyName = "Batman",
    		Name = "UserModel",
    		Roles = new[] {new RoleModel(), new RoleModel() }
    	};
    	
    	var userViewModel = AutoMapper.Mapper.Map<UserViewModel>(userModel);
    	Console.WriteLine(userViewModel.ToString());
    }
    
    // Define other methods and classes here
    public class UserModel
    {
        public string Name {get;set;}
        public IEnumerable<RoleModel> Roles { get; set; }
    	public string DifferentPropertyName { get; set; }
    }
    
    public class UserViewModel 
    {
        public string Name {get;set;}
        public IEnumerable<RoleModel> Roles { get; set; } // notice the ViewModel
    	public string Thingy { get; set; }
    	
    	public override string ToString()
    	{
    		var sb = new StringBuilder();
    		sb.AppendLine(string.Format("Name: {0}", Name));
    		sb.AppendLine(string.Format("Thingy: {0}", Thingy));
    		sb.AppendLine(string.Format("Contains #{0} of roles", Roles.Count()));
    		
    		return sb.ToString();
    	}
    }
    
    public class UserModelToUserViewModelConverter : TypeConverter<UserModel, UserViewModel>
    {
    	protected override UserViewModel ConvertCore(UserModel source)
    	{
    		if(source == null)
    		{
    			return null;
    		}
    
            //You can add logic here to deal with nulls, empty strings, empty objects etc
    		var userViewModel = new UserViewModel
    		{
    			 Name = source.Name,
    			 Roles = source.Roles, 
    			 Thingy = source.DifferentPropertyName
    		};
    		return userViewModel;
    	}
    }
    
    public class RoleModel
    {
    	//no content for ease, plus this has it's own mapper in real life
    }
