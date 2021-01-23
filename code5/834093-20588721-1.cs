    //our new base type
    public interface IElementAndDropTarget : IDropTarget
    {
    	void DoSomethingAsUIElement();
    	void MoreUIElementAndDropStuff();
    }
    
    // our decorator. We need to store UIElement and IDropTarget
    // as different fields. The static "Make" is giving you
    // the compile-time guarantee that they both refer
    // to the same class
    public class UIElementDecorator : IElementAndDropTarget
    {
    	private readonly UIElement t;
    	private readonly IDropTarget dt;
    	
    	private UIElementDecorator(UIElement t, IDropTarget dt)
    	{	
    		this.t=t;
    		this.dt=dt;
    	}
    
    	public static UIElementDecorator Make<T>(T t) where T: UIElement, IDropTarget
    	{
    		return new UIElementDecorator(t,t);
    	}
    
    	public void DoSomethingAsUIElement() {t.DoSomethingAsUIElement();}
    	public void MoreUIElementAndDropStuff(){t.MoreUIElementAndDropStuff();}
    	public void DoSomethingAsIDropTarget() {dt.DoSomethingAsIDropTarget();}
    }
