    //The Following function will Take the Class object as an Argument and return the JSON obect as String, 
        //Please use the following namespace 
    using System.Web.Script.Serialization;
    
        public string ConvertObjecttoJSON(object clsobj)
        {
    
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
                  new System.Web.Script.Serialization.JavaScriptSerializer();
    
    
            string jsonString = serializer.Serialize(clsobj); 
            Console.WriteLine(jsonString);
            return jsonString;
    
        }
