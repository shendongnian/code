    // Placed outside of the class
    public delegate void CampaignDetailSelectedEventHandler(ListItem listItem);
    
    // Test class to show to convert from vb.net to C# 
    public class Test : ICampaignMaintenanceView
    {
    	public event CampaignDetailSelectedEventHandler CampaignDetailSelected; 
    	
    
    	protected virtual void OnCampaignDetailSelected(ListItem listItem)
    	{
    		if (CampaignDetailSelected != null)
    		{
    			CampaignDetailSelected(listItem);
    		}
    	}
    }
