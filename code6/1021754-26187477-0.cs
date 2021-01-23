    public class Dependent
    {
        public Dependent()
        {
        }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; } // Use a nullable object to hold the error value
    }
    void DeserializeTest()
    {
       string dependents = @"[
	                            {
	                                ""FirstName"": ""Kenneth"",
	                                ""DateOfBirth"": ""02-08-2013""
	                            },
	                            {
	                                ""FirstName"": ""Ronald"",
	                                ""DateOfBirth"": ""asdf""
	                            }
	                      ]";
						  
		var messages = new List<string>();
	
		var settings = new JsonSerializerSettings(){
			Error = (s,e)=>{
				var depObj = e.CurrentObject as Dependent;
				if(depObj != null)
				{
					messages.Add(string.Format("Obj:{0} Message:{1}",depObj.FirstName, e.ErrorContext.Error.Message));
				}
				else 
				{
					messages.Add(e.ErrorContext.Error.Message);
				}
				e.ErrorContext.Handled = true; // Set the datetime to a default value if not Nullable
			}
		};
		var ndeps = JsonConvert.DeserializeObject<Dependent[]>(dependents, settings);
		//ndeps contains the serialized objects, messages contains the errors
	}
