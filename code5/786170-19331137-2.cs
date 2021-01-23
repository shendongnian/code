    public delegate void EventFiredHandler(object sender);
    
    public class MyUserControl: UserControl
    {
    	public event EventFiredHandler EventFired;
    
    	//Let all your button clicks in usercontrol share this event sink
    	void Button1_Click(object sender, EventArgs e)
    	{
    		if(EventFired != null)
    		{
    			EventFired(sender);
    		}
    	}
    }
