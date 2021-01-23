    void Main()
    {
    	IPageShape pageInfo = ComTransformer.GetPageShape(comObject);
    }
    
    interface IPageShape {
       int Width { get; set; }
       int Height { get; set; }
    }
    
    class PageShapeImpl : IPageShape {
    	public int Width { get; set; }
    	public int Height { get; set; }
    }
    
    static class ComTransformer {
    	public static IPageShape GetPageShape(dynamic obj) {
    		return new PageShapeImpl {
    			Width = (int) obj.Width,
    			Height = (int) obj.Height
    		};
    	}
    }
