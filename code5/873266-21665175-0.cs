    public class ToolTip : PlaceHolder
    {
    	protected override void CreateChildControls()
    	{
    		HtmlGenericControl div1 = new HtmlGenericControl("div");
    		div1.Attributes.Add("id", ClientID);
    		div1.Attributes.Add("class", "tooltip");
    		while (Controls.Count != 0)
    			div1.Controls.Add(Controls[0]);
    		Controls.Add(div1);
    	}
    }
