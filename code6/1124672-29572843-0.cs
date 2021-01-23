    using System.IO;
    using Newtonsoft.Json;
    
    namespace test
    {
        public void writeObject( object myObj){ 
            using (StreamWriter myFile = new StreamWriter(myPath))
            { 
                newFile.WriteLine(JsonConvert.SerializeObject(myObj));
            }   
        }
    }
