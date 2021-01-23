    public interface IDashboard
    {
    	void SaveToXml(Stream stream);
    }
    
    public class DashboardWrapper : IDashboard
    {
    	private readonly Dashboard dashboard = new Dashboard();
    	
    	public void SaveToXml(Stream stream)
    	{
    		this.dashboard.SaveToXml(stream);
    	}
    }
