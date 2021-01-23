    class Program
    {
        static void Main(string[] args)
        {
            Response response = new Response();
            response.ResponseStatus = "ok";
            //ConcreteCommand command = new ConcreteCommand();    //switch with line below to test inteface
            InterfaceCommand command = new InterfaceCommand();
            command.Execute();
            response.Results = command.Results;
            List<Type> knownTypes = new List<Type>
            {
                typeof(MyObject),
                typeof(Result<MyObject>)                  //switch with line below to test inteface
                //typeof(Result<IMyObject>)
            };
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(response.GetType(), knownTypes, int.MaxValue, false, null, true);
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, response);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string output = reader.ReadToEnd();
            Console.WriteLine(output);
        }
    }
    public interface IMyObject
    {
        string name { get; set; }
    }
    [DataContract]
    public class MyObject : IMyObject
    {
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Result<T>
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public T Item { get; set; }
    }
    public abstract class BaseCommand
    {
        protected Result<IMyObject> results = new Result<IMyObject>();
        public Result<IMyObject> Results
        {
            get { return this.results; }
        }
        public abstract void Execute();
    }
    public class InterfaceCommand : BaseCommand
    {
        public override void Execute()
        {
            IMyObject myobject = new MyObject();
            myobject.name = "my object";
            Result<IMyObject> result = new Result<IMyObject>();
            result.Item = myobject;
            result.Status = "ok";
            this.results= result;
        }
    }
    public class ConcreteCommand : BaseCommand
    {
        public override void Execute()
        {
            MyObject myobject = new MyObject();
            myobject.name = "my object";
            Result<IMyObject> result = new Result<IMyObject>();
            result.Item = myobject;
            result.Status = "ok";
            this.results = result;
        }
    }
    [DataContract]
    public class Response
    {
        [DataMember]
        public string ResponseStatus { get; set; }
        [DataMember]
        public Result<IMyObject> Results { get; set; }
    }
