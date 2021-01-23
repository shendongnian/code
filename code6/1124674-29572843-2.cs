    using System.IO;
    using Newtonsoft.Json;
    
    namespace test
    {
        public MyObject readObject(){
            var result;  
            using (StreamReader file = new StreamReader(myPath))
            { 
                result = JsonConvert.DeserializeObject<MyObject>(file.ReadToEnd());
                file.Close();
            }   
            return result;
        }
    } //Notice that "MyObject" could be even a collection of your objects, like List<Customer> and you can deserialize all in once.
