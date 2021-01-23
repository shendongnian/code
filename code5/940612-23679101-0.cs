    class Object
    {
    	private Type _value;
    	
        public Type objType{ 
    	
    		get{ return _value; }
    		set{
    			if(value != Type.One && value != Type.Three)
    				throw new ArgumentOutOfRangeException();
    			else
    				_value = value;
    		}
    	}
    }
