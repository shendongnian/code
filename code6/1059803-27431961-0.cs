    public static void main() {
        var builder = new ProcessorBuilder();
        ProcessorDirector director = new ProcessorDirector();
        director.Build();
        Console.WriteLine(builder.Processor);
    }
    class ProcessorDirector { //I tell processor builders how to build processors!
        ProcessorBuilder _builder {get;private set;}
        public ProcessorDirector(ProcessorBuilder builder) {
            _builder = builder;
        }
        public void Build() {
            var credentials = _builder.GetCredentialsFromDB();
            var data = _builder.ProcessData(credentials);
            var isDataValid = _builder.ValidateData();
            if(isDataValid) {
                 _builder.ParseData();
            }
        }
    }
    class ProcessorBuilder
    {
        public string Processor {get;set;}
        void ProcessorBuilder()
        {
            //if you change your end result object into a non-value type, you'd initialize it here.
        }
        public string GetCredentialsFromDb()
        {
            return "user";
        }
        string ProcessData(string credentials)
        {
            //process
            //builder should be stateless, so return data
        }
        public string ParseData()
        {
            //parse
        }
        public string ValidateData()
        {
            //validate
        }
    }
