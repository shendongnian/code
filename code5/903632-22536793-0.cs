    using System.Collections.Generic;
    namespace ConsoleApplication1 {
      public class Resource {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      }
      class Program {
        static void Main(string[] args) {
          var foo = @"{
              ""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",
              ""Resource"":{""$type"":""ConsoleApplication1.Resource, ConsoleApplication1"",
                 ""FirstName"":""rrr"",
                 ""LastName"":null}}";
          var bar = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(
            foo, 
            new Newtonsoft.Json.JsonSerializerSettings {
              TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
          });
      
        }
      }
    }
