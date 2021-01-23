        using UnityEngine;
        using System.Collections;
        using NExtensionMethods;
        
        public class TDefault:MonoBehaviour,IDefault
        {
        	public  TEssentail essential=new TEssentail();
        	public TEssentail get_essential()
        	{
        		if(essential==null)
        			essential=new TEssentail();
        		return essential;
        	}
        	
        	public TDefault ()
        	{
        	}
        }
