    public abstract class EnumBase<T> where T : EnumBase<T>
    {
        private List<T> values = new List<T>();
        public ReadOnlyCollection<T> Values
        {
            get
            {
                return values.AsReadOnly();
            }
        }
    
        public string name { get; private set; }
    
        protected EnumBase()
        {
            
        }
    
    	public string addEnum()
    	{
    		this.name = name;
            values.Add((T)this);
    	}
    	
        public override string ToString()
        {
            return this.name;
        }
    }
    
    using System;
    
    public class Day : EnumBase<Day>
    {
    	private static Day instance;
    	private Day() {}
    
    	public static Day Instance
    	{
    		get 
    		{
    			if (instance == null)
    			{
    				instance = new Day();
    			}
    			return instance;
    		}
    	}
    	addEnum('monday');
    	addEnum('tuesday');
    }
