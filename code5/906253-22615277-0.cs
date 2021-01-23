    public partial class ConLib_Custom_ProductDialog : System.Web.UI.UserControl
    {
    	public bool _EventSelected;
    	
    	public void SomeFunctionThatCreatesQtyBoxTemplate()
    	{
    		var q = new QtyBoxTemplate(this); //Include reference to itself
    		q.SetEventSelected();
    	}
    	
    	private class QtyBoxTemplate : System.Web.UI.ITemplate
    	{
    		private ConLib_Custom_ProductDialog _ccp;
    		
    		public QtyBoxTemplate(ConLib_Custom_ProductDialog ccp)
    		{
    			_ccp = ccp;
    		}
    		
    		public void SetEventSelected()
    		{
    			_ccp._EventSelected = true; //Access to "parent" EventSelected 
    		}
    	}
    }
