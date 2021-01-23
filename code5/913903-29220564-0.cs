    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    
    namespace CommandLineProgram
    {
    	public class DefaultProgram
    	{
    		public static void Main(string[] args)
    		{
    			List<String> FolderList = new List<string>() { "L0", "L1", "L2" };
    			DateTime FromDate = DateTime.Now;
    			DateTime ToDate = DateTime.Now;
    			String ContactName = "ContactName";
    			String Email = "contact@email.com";
    
    			XElement folderPath = new XElement(FolderList[0],
    				new XAttribute("fromDate", FromDate),
    				//attributes for Folder w/ lots of attributes
    				new XAttribute("toDate", ToDate),
    				new XAttribute("contactName", ContactName),
    				new XAttribute("email", Email));
    
    			XElement previousNode = folderPath;
    			for (int i = 1; i < FolderList.Count; i++)
    			{
    				XElement newNode = new XElement(FolderList[i]);
    				previousNode.Add(newNode);
    				previousNode = newNode;
    			}
    		}
    	}
    }
