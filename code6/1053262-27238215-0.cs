    using System;				
    using System.Collections.Generic;
    using System.Linq;
    	
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	// Solution to SO Question: http://stackoverflow.com/q/27217095/325521
    	// This Answer: http://stackoverflow.com/a/27238215/325521
    	// Author: Shiva Manjunath
    	// SO Profile: http://stackoverflow.com/users/325521/shiva
    	public static void Main()
    	{		
           string jsonString = @"{
    							 ""response"" : {
    							  ""method"" : ""my.current.method"",
    							  ""result"" : {
    								 ""current_calls"" : {
    									""current_call"" : [
    									   {
    										  ""provider"" : ""ABC"",
    										  ""start_time"" : ""2014-11-30 02:24:52"",
    										  ""duration"" : ""5"",
    										  ""to_caller_id_number"" : ""800"",
    										  ""state"" : ""ivr"",
    										  ""from_caller_id_name"" : ""<unknown>"",
    										  ""to_caller_id_name"" : ""Main Answer Queue"",
    										  ""format"" : ""ulaw"",
    										  ""from_caller_id_number"" : ""1234567890"",
    										  ""id"" : ""SIP/1234567890-08682a00""
    									   },
    									   {
    										  ""provider"" : ""ThinkTel"",
    										  ""start_time"" : ""2014-11-30 02:24:50"",
    										  ""duration"" : ""7"",
    										  ""to_caller_id_number"" : ""800"",
    										  ""state"" : ""ivr"",
    										  ""from_caller_id_name"" : ""<unknown>"",
    										  ""to_caller_id_name"" : ""Main Answer Queue"",
    										  ""format"" : ""ulaw"",
    										  ""from_caller_id_number"" : ""0123456789"",
    										  ""id"" : ""SIP/0123456789-08681350""
    									   }
    									],
    									""total_items"" : ""2""
    								 }
    								}
    							  }
    						    }";
    		
    		Console.WriteLine("BEGIN JSON Deserialization\n");
    		var callData = Newtonsoft.Json.JsonConvert.DeserializeObject<CallData>(jsonString);
    			// extract the current list of calls in the response
    		var callsList = callData.response.result.current_calls.current_call;
    			// check if there are any calls
    		if (callsList.Any())
    		{
    			Console.WriteLine("    Number of Call Records Received via JSON = {0}\n", callsList.Count());
    			int i = 1;
    				// print out call details for each call.
    			foreach(var oneCall in callsList)
    			{
    				Console.WriteLine("    Call #" + i);
    				Console.WriteLine("      provider: " + oneCall.provider);
    				Console.WriteLine("      start_time: " + oneCall.start_time);
    				Console.WriteLine("      duration: " + oneCall.duration);
    				Console.WriteLine("      to_caller_id_number: " + oneCall.to_caller_id_number);
    				Console.WriteLine("      state: " + oneCall.state);
    				Console.WriteLine("      from_caller_id_name: " + oneCall.from_caller_id_name);
    				Console.WriteLine("      to_caller_id_name: " + oneCall.to_caller_id_name);
    				Console.WriteLine("      format: " + oneCall.format);
    				Console.WriteLine("      from_caller_id_number: " + oneCall.from_caller_id_number);
    				Console.WriteLine("      id: {0}\n", oneCall.id);
    				i++;
    			}			
    		}
    		Console.WriteLine("\nEND JSON Deserialization");
    	}
    }
    
    public class CurrentCall
    {
        public string provider { get; set; }
        public string start_time { get; set; }
        public string duration { get; set; }
        public string to_caller_id_number { get; set; }
        public string state { get; set; }
        public string from_caller_id_name { get; set; }
        public string to_caller_id_name { get; set; }
        public string format { get; set; }
        public string from_caller_id_number { get; set; }
        public string id { get; set; }
    }
    
    public class CurrentCalls
    {
        public List<CurrentCall> current_call { get; set; }
        public string total_items { get; set; }
    }
    
    public class Result
    {
        public CurrentCalls current_calls { get; set; }
    }
    
    public class Response
    {
        public string method { get; set; }
        public Result result { get; set; }
    }
    
    public class CallData
    {
        public Response response { get; set; }
    }
