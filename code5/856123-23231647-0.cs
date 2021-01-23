    public class PaddedUIView<T>: UIView where T : UIView, new()
    {
    	private float _padding;
    	private T _nestedView;
    
    	public PaddedUIView()
    	{
    		Initialize();
    	}
    
    	public PaddedUIView(RectangleF bounds)
    		: base(bounds)
    	{
    		Initialize();
    	}
    
    	void Initialize()
    	{   
    		if(_nestedView == null)
    		{ 
    			_nestedView = new T();
    			this.AddSubview(_nestedView);
    		}
    		_nestedView.Frame =  new RectangleF(_padding,_padding,Frame.Width - 2 * _padding, Frame.Height - 2 * _padding);
    	}
    
    	public T NestedView
    	{ 
    		get { return _nestedView; }
    	}
    
    	public float Padding
    	{
    		get { return _padding; }
    		set { if(value != _padding) { _padding = value; Initialize(); }}
    	}
    
    	public override RectangleF Frame
    	{
    		get { return base.Frame; }
    		set { base.Frame = value; Initialize(); }
    	}
    }
