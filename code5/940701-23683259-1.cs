        public class Child
        {
        	private Parent _parent;
        	
        	public Child(Parent parent)
        	{
        		_parent = parent;
        	}
        
            public string ParentPropertyName { 
                get { return GetParentPropertyName(_parent, this); } 
            }
        }
