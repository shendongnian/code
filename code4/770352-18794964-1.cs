    using System;
    using System.Linq;
    using System.Data;
    using System.Data.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace OverwritingClassObjectHelp
    {
    	public class someObject
    	{
    		//Line 1
    		public int Line1_ID;
    		public string Line1_Attribute1;
    		public string Line1_Attribute2;
    
    		//Line 2
    		public int Line2_ID;
    		public decimal Line2_Attribute3;
    		public string Line2_Attribute4;
    
    		//Line 3
    		public int Line3_ID;
    		public decimal data_pos1;
    		public decimal data_pos2;
    		public decimal data_pos3;  
    
    		//Line 4
    		public int Line4_ID;
    		public decimal data_pos4;
    		public decimal data_pos5;
    		public decimal data_pos6; 
    	}
    
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string filepathRead = @"C:\Users\C121736\Desktop\SampleFile.txt";
    			List<someObject> somObList = new List<someObject>();
    			try
    			{
    				FileStream fs = new FileStream(filepathRead, FileMode.Open, FileAccess.Read);
    				StreamReader reader = new StreamReader(fs);
                                someObject obj_1 = null;
                                   
    				while (!reader.EndOfStream) 
    				{                         
    					string line = reader.ReadLine();
    					
    
    					if(String.IsNullOrWhiteSpace(line))
    					{
    						// if line is empty do nothing
    						continue;
    					}
    					else if ((line.Substring(0, 4) == "1000"))
    					{
    						// normalize
    						line = Regex.Replace(line, @"\s+", " ");
    						string[] strArrFields = line.Split();
    
    						obj_1 = new someObject();                        
    						obj_1.Line1_ID = int.Parse(strArrFields[0]);
    						obj_1.Line1_Attribute1 = strArrFields[1];
    						obj_1.Line1_Attribute2 = strArrFields[2];
    					}
    
    					else if ((line.Substring(0, 4) == "1001"))
    					{
    						if(obj_1 == null) continue;
    
    						// normalize
    						line = Regex.Replace(line, @"\s+", " ");
    						string[] strArrFields = line.Split();
    
    
    						obj_1.Line2_ID = int.Parse(strArrFields[0]);
    						obj_1.Line2_Attribute3 = decimal.Parse(strArrFields[1]);
    						obj_1.Line2_Attribute4 = strArrFields[2];
    						somObList.Add(obj_1);
    					}
    				 	
    					else if(line.Substring(0, 4) == "1003") 
    					{
    						if(obj_1 == null) continue;
    
    						// normalize
    						line = Regex.Replace(line, @"\s+", " ");
    						string[] strArrFields = line.Split();
    
    						obj_1.Line3_ID = int.Parse(strArrFields[0]);
    						obj_1.data_pos1 = decimal.Parse(strArrFields[1]);
    						obj_1.data_pos2 = decimal.Parse(strArrFields[2]);
    						obj_1.data_pos3 = decimal.Parse(strArrFields[3]);
    					}
    					else if(line.Substring(0, 4) == "1004")
    					{
    						if(obj_1 == null) continue;
    
    						// normalize
    						line = Regex.Replace(line, @"\s+", " ");
    						string[] strArrFields = line.Split();
    
    
    						obj_1.Line4_ID = int.Parse(strArrFields[0]);
    						obj_1.data_pos4 = decimal.Parse(strArrFields[1]);
    						obj_1.data_pos5 = decimal.Parse(strArrFields[2]);
    						obj_1.data_pos6 = decimal.Parse(strArrFields[3]);
    						somObList.Add(obj_1);
    						obj_1 = null;
    					}
    				} 
    			}
    			catch (FileNotFoundException ex)
    			{
    				Console.WriteLine(ex.Message);
    				Console.WriteLine("Program Exited");
    				Environment.Exit(99);
    			}             
    			foreach (someObject o in somObList)
    			{
    				Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8},{9}",
    				                  o.Line1_ID, o.Line1_Attribute1, o.Line1_Attribute2, o.Line2_ID, o.Line2_Attribute3, o.Line2_Attribute4, o.Line3_ID, o.data_pos1, o.data_pos2, o.data_pos3);
    			}
    			somObList.Clear();
    		}
    	}
    }
