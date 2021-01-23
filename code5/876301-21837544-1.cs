    protected override void OnInit(EventArgs e)
    {
    	base.OnInit(e);
    	grid.DataSource = new[] { 
    		new MyObject()
    		{
    			MyEnumValue = MyEnum.MyEnumStringValue,
    		}};
    	grid.DataBind();
    }
    
    public class MyObject
    {
    	public MyEnum MyEnumValue { get; set; }
    }
    public enum MyEnum
    {
    	MyEnumStringValue,
    }
