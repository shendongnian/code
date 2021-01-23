    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace Reset_Client
    {
    static class Program
    {
        static void Main()
        {
            string path = @"\Storage Card\deneme\";
            File.Delete(path + "Agentry.ini");
            File.Delete(path + "Agentry.app");
            File.Delete(path + "Agentry.usr");
            //DF(path);
            DD(path);
            MessageBox.Show("Cihaz resetlendi!");
        }
    
        public static void DD(string mainPath)
        {
            try
            {
                ClearFolder(mainPath + "CRM");
                ClearFolder(mainPath + "BHTS");
                ClearFolder(mainPath + "IMAGES");
                ClearFolder(mainPath + "STYLES");
                ClearFolder(mainPath + "TABLES");
                ClearFolder(mainPath + "LOG");
    
            }
            catch (IOException e)
            {
                DD(mainPath);
            }
        }
    
    	public void ClearFolder(string folderName)  
    	{  
    		DirectoryInfo dir = new DirectoryInfo(folderName);  
    		foreach (FileInfo fi in dir.GetFiles())  
    		{  
    			fi.Delete();  
    		}  
    		foreach (DirectoryInfo di in dir.GetDirectories())  
    		{  
    			ClearFolder(di.FullName);  
    			di.Delete();  
    		}  
    	}  
    }
    }
