    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Objects;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.Xml;
    using ConsoleDemo.Controller;
    using ConsoleDemo.Model;
    using Microsoft.Practices.Unity;
    
    
    namespace ConsoleDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = @"{""Root"": {""data"": [{""CardName"": ""card1"",""functions"": [{""State"": ""OPEN""},{""State"": ""INHERENT""}]},{""CardName"": ""card2"",""functions"": [{""State"": ""CLOSED""},{""State"": ""INHERENT""}]}]}";
                RootClass dynObj = JsonHelper.JsonDeserialize<RootClass>(data); //Get the object
                Console.ReadKey();
            }
        }
    
        [DataContract]
        public class RootClass
        {
            [DataMember(Name = "Root")]
            public Data Root { get; set; }
        }
    
        [DataContract]
        public class Data
        {
            [DataMember(Name = "data")]
            public List<Card> data { get; set; }
        }
    
        [DataContract]
        public class Card
        {
            [DataMember(Name = "CardName")]
            public string CardName { get; set; }
    
            [DataMember(Name = "functions")]
            public List<Function> Functions { get; set; }
        }
    
        [DataContract]
        public class Function
        {
    
            [DataMember(Name = "State")]
            public string State { get; set; }
        }
    
        public class JsonHelper
        {
            /// <summary>
            /// JSON Serialization
            /// </summary>
            public static string JsonSerializer<T>(T t)
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                var ms = new MemoryStream();
                ser.WriteObject(ms, t);
                var jsonString = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return jsonString;
            }
            /// <summary>
            /// JSON Deserialization
            /// </summary>
            public static T JsonDeserialize<T>(string jsonString)
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                var obj = (T)ser.ReadObject(ms);
                return obj;
            }
        }
    
    }
