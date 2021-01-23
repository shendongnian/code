    public class JsonObject
        {
            public string CompiledString { get; set; }
    
            private string _Category;
            public string Category 
            { 
                get
                { 
                    return _Category; 
                }
                set
                {
                    _Category = value;
                    CompileString();
                }
            }
    
            private string _EntityID;
            public string EntityID
            {
                get
                {
                    return _EntityID;
                }
                set
                {
                    _EntityID = value;
                    CompileString();
                }
            }
            //Rest of the properties go here
    
            private void CompileString()
            {
                //cycle through each of your properties and update the CompiledString variable
                CompiledString =
                    _Category == null ? string.Empty : _Category + "," +
                    _EntityID == null ? string.Empty : _EntityID + ",";
                //I left the last comma in there because you will be adding other props... just remember to exclude it from the last one.
    
                //Of course this part of the implementation is entirely up to you, your question was about how to do it through the property
            }
        }
