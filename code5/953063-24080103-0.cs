    public partial class abstract_questions
    	{
    		private static int _newIdentity = 0;
    
    		partial void OnCreated()
    		{
    			//Set an identity value so when two new entities
                        // are created Entity Framework doesn't whinge 
                        // on the server because of duplicate keys
    			_newIdentity = _newIdentity - 1;
    
                        // Set whatever is defined as the identity/pk property
    			this.Id = _newIdentity;
    		}
