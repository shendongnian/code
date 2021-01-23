       public static void Main()
        {
            int[,] B = new int[2, 5];
            B[0, 0] = 5;
            B[0, 1] = 3;
            B[0, 2] = 5;  
            DeepSerialize<int[,]>( B,"test3");
            int[,] des= DeepDeserialize<int[,]>("test3");
         
            
            
        }
   
     public static void DeepSerialize<T>(T obj,string fileName)
        {
            //            MemoryStream memoryStream = new MemoryStream();
            FileStream str = new FileStream(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(str, obj);
            str.Close();
        }
        public static T DeepDeserialize<T>(string fileName)
        {
            //            MemoryStream memoryStream = new MemoryStream();
            FileStream str = new FileStream(fileName, FileMode.Open);
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T returnValue = (T)binaryFormatter.Deserialize(str);            
            str.Close();
            return returnValue; 
        }  
