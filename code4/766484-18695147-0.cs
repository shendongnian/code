    	public sealed class RequiredAttributeAttribute : Attribute
    	{
    		private Operation _Operations = Operation.Insert | Operation.Update;
    		public Operation Operations
    		{
    			get { return this._Operations; }
    			set { this._Operations = value; }
    		}
    
    		public string ErrorMessage { get; set; }
    	}
    
    	[Flags]
    	public enum Operation
    	{
    		Insert = 2,
    		Update = 4,
    		Delete = 6
    	}
