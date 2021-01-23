    // Create a Super class as in the following example (OutputData) and Add your child classes to it 
    
        public class OutputData
        {
            public OutputData()
            {
                //
                // TODO: Add constructor logic here
                //
            }
            public JsonData1 jsondata1 = new JsonData1();
            public JsonData2 jsondata2 = new JsonData2();
        }
    
    
    
        public void AddJsonData ()
        {
        // And in the Function which addes data to the JsonData1 and JsonData2 Add the folloiwng lines.
            
            JsonData1  jsondata1  = new JsonData1 ();
            JsonData1  jsondata2  = new JsonData2 ();
            OutputData outputdata = new OutputData();
            string JsonOutput = "";
    
        //Assign the Json data classes with data to the SuperClass object
            outputdata.JsonData1 = jsondata1 ;
            outputdata.JsonData2 = jsondata2 ;  
    
        // Add some Data to your Json Classes
    
            jsondata1.UserName= "ABCD";
            jsondata1.UserID= "AB12";
    
            jsondata2.Country = "OOO";
            jsondata2.City = "CCC";
            
            //Create an object of the Json convert Class
    
            ConvertOutput convertoutput = new ConvertOutput();
            
            try
            {
                 JsonOutput = convertoutput.ConvertObjecttoJSON(outputdata);
            }
        }
    
    public class ConvertOutput
    {
    
        public string ConvertObjecttoJSON(object clsobj)
        {
    
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
                  new System.Web.Script.Serialization.JavaScriptSerializer();
    
            string jsonString = serializer.Serialize(clsobj); 
            //Console.WriteLine(jsonString);
            return jsonString;
        }
    
    }
    
    
    // And in your Angular JS, Ajax/JavaScript Refer the output object with Each Classnames. 
    
    //if you check the Json output text file you can see how each class objects are added to it.
    
        success: function (data) {                
                  
                var msg1 = JSON.stringify(data);
                var msg = JSON.parse(msg1);
                
            var strName = msg.jsondata1.UserName;
            var strCountry = msg.jsondata2.Country;
    
        });
    
    // Happy Coding Everyone, hope this helps. 
    // Cheeers
    // C J
