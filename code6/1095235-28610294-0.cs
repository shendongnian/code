    public abstract class ALayer
    {
    	int Id { get; set; }
    }
    
    public abstract class A<T> where T : ALayer
    {
    	protected List<T> Layers { get; set; }
    }
    
    public class B : A<BLayer>
    {
    	//I want to apply the polymorphism in the constructor
    	public B()
    	{
    		this.Layers = new List<BLayer>();
    	}
    }
    
    public class BLayer : ALayer
    {
    	int blayerattr { get; set; }
    }
