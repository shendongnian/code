    using SHDocVw;
    ....
        public class IEClass
        {
        	List<InternetExplorer> IEWindows;
        
        	public IEClass()
        	{
        		IEWindows = new List<InternetExplorer>();
        	}
        
        	public List<InternetExplorer> GetIEInstances()
        	{
        		IEWindows.Clear();
        		ShellWindows shellWindows = new ShellWindows();
        		string filename;
        
        		foreach (InternetExplorer ie in shellWindows)
        		{
        			filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
        			if (filename.Equals("iexplore"))
        			{
        				IEWindows.Add(ie);
        			}
        		}
        		return IEWindows;
        	}
        
        	public bool QuitInstance(int key)
        	{
        		InternetExplorer ie = (InternetExplorer)IEWindows[key];
        
        		try
        		{
        			ie.Quit();
        			return true;
        		}
        		catch (Exception ex)
        		{
        			// handle any exception
        		}
        		return false;
        	}
        	
        	public void StartInstance(string url)
        	{
        	    InternetExplorer ie = new InternetExplorer();
        
        		ieInstance.Visible = true;
        		ieInstance.Navigate2(ref (object)url, ref Empty, ref Empty, ref Empty, ref Empty);
        		IEWindows.Add(ie);
        	}
        }
