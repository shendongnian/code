    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Reflection;
    using System.Collections.Generic;
    
    namespace iPhoneHardDriveCRUDPrototype
    {
    	public static class HardDriveService
    	{
    		private static string docsFolderPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
    		private const string fileName = "AllUserCollections.xml";
    		private static string filePath = Path.Combine(docsFolderPath, fileName);
    
    		private static bool FileExists(string fullFilePath)
    		{
    			if (File.Exists (fullFilePath)) 
    				return true;
    
    			return false;
    		}
    
    		public static void Save(AllUserCollections allUserCollections)
    		{
    			if (FileExists(filePath))
    			{
    				File.Delete (filePath);
    			}
    
    			XmlSerializer serializer = new XmlSerializer(allUserCollections.GetType());
    			using(StreamWriter writer = new StreamWriter(filePath))
    			{
    				serializer.Serialize(writer.BaseStream, allUserCollections);
    			}
    		}
    
    		public static AllUserCollections Read()
    		{
    			AllUserCollections allUserCollections = new AllUserCollections();
    			XmlSerializer serializer = new XmlSerializer(allUserCollections.GetType());
    
    			if (FileExists(filePath))
    			{
    				StreamReader reader = new StreamReader(filePath);
    				object deserialized = serializer.Deserialize(reader.BaseStream);
    				allUserCollections = (AllUserCollections)deserialized;
    			}
    
    			return allUserCollections;
    		}
    
    
    	}//End of class.
    }
