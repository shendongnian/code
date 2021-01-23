    internal class WorkerItem
    {
    	public WorkerItem(List<SPListItem> spListItems, string destinationListName, string destinationServerURL)
    	{
    		SPListItems = new List<SPListItem>(spListItems);
    		DestinationListName = destinationListName;
    		DestinationServerURL = destinationServerURL;
    	}
    
    	public List<SPListItem> SPListItems { get; private set; }
    	public string DestinationListName { get; private set; }
    	public string DestinationServerURL { get; private set; }
    }
