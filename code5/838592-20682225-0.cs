    using System;
    using System.Collections.Generic;
    
    namespace iPhoneHardDriveCRUDPrototype
    {
    	[Serializable]
    	public class AllUserCollections
    	{
    		public List<UserCollection> UserCollections { get; set; }
    
    		public AllUserCollections()
    		{
    			this.UserCollections = new List<UserCollection> ();
    		}
    	}
    
    	[Serializable]
    	public class UserCollection
    	{
    		public string UserGroup { get; set; }
    		public SerializableDictionary<int,User> Users { get; set; }
    
    		public UserCollection()
    		{
    			this.Users = new SerializableDictionary<int, User> ();
    		}
    
    		public UserCollection(string userGroup)
    		{
    			this.UserGroup = userGroup;
    			this.Users = new SerializableDictionary<int, User> ();
    		}
    	}
    
    	[Serializable]
    	public class User
    	{
    		public int ID { get; set; }
    		public string Name { get; set; }
    		public string Location { get; set; }
    		public AgeGroup UserAgeGroup { get; set; }
    
    		public User()
    		{
    
    		}
    	}
    
    	[Serializable]
    	public enum AgeGroup
    	{
    		Twenties,
    		Thirties,
    		Fourties,
    	}
    }
