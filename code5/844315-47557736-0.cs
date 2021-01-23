    public class ChildClass : ParentClass
    {
    
        
    	public ChildClass(ParentClass ch)
    	{
            foreach (var prop in ch.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(ch, null), null);
            }
    	}
    }
