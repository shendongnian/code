    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Web;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    
    	// SO Question: http://stackoverflow.com/questions/27132887/
    	// This (my) Answer: 
    	// Author: Shiva Manjunath
    	// SO Profile: http://stackoverflow.com/users/325521/shiva
    public class Program
    {	
    	public static void Main()
    	{
    		
           string jsonString = @"{
      ""metadata"": {
        ""columnGrouping"": [
          ""area"",
          ""metricType"",
          ""period"",
          ""valueType""
        ],
        ""rowGrouping"": []
      },
      ""columns"": [
        {
          ""area"": {
            ""identifier"": ""E31000040"",
            ""label"": ""Gtr Manchester Fire"",
            ""altLabel"": ""Gtr Manchester Fire"",
            ""isSummary"": false
          },
          ""metricType"": {
            ""identifier"": ""948"",
            ""label"": ""Accidental dwelling fires"",
            ""altLabel"": ""Accidental dwelling fires"",
            ""isSummary"": false
          },
          ""period"": {
            ""identifier"": ""fq_Q1_2013_14"",
            ""label"": ""2013/14 Q1"",
            ""altLabel"": ""2013/14 Q1"",
            ""isSummary"": false
          },
          ""valueType"": {
            ""identifier"": ""raw"",
            ""label"": ""Raw value"",
            ""isSummary"": false
          }
        },
        {
          ""area"": {
            ""identifier"": ""E31000040"",
            ""label"": ""Gtr Manchester Fire"",
            ""altLabel"": ""Gtr Manchester Fire"",
            ""isSummary"": false
          },
          ""metricType"": {
            ""identifier"": ""948"",
            ""label"": ""Accidental dwelling fires"",
            ""altLabel"": ""Accidental dwelling fires"",
            ""isSummary"": false
          },
          ""period"": {
            ""identifier"": ""fq_Q2_2013_14"",
            ""label"": ""2013/14 Q2"",
            ""altLabel"": ""2013/14 Q2"",
            ""isSummary"": false
          },
          ""valueType"": {
            ""identifier"": ""raw"",
            ""label"": ""Raw value"",
            ""isSummary"": false
          }
        },
        {
          ""area"": {
            ""identifier"": ""E31000040"",
            ""label"": ""Gtr Manchester Fire"",
            ""altLabel"": ""Gtr Manchester Fire"",
            ""isSummary"": false
          },
          ""metricType"": {
            ""identifier"": ""948"",
            ""label"": ""Accidental dwelling fires"",
            ""altLabel"": ""Accidental dwelling fires"",
            ""isSummary"": false
          },
          ""period"": {
            ""identifier"": ""fq_Q3_2013_14"",
            ""label"": ""2013/14 Q3"",
            ""altLabel"": ""2013/14 Q3"",
            ""isSummary"": false
          },
          ""valueType"": {
            ""identifier"": ""raw"",
            ""label"": ""Raw value"",
            ""isSummary"": false
          }
        },
        {
          ""area"": {
            ""identifier"": ""E31000040"",
            ""label"": ""Gtr Manchester Fire"",
            ""altLabel"": ""Gtr Manchester Fire"",
            ""isSummary"": false
          },
          ""metricType"": {
            ""identifier"": ""948"",
            ""label"": ""Accidental dwelling fires"",
            ""altLabel"": ""Accidental dwelling fires"",
            ""isSummary"": false
          },
          ""period"": {
            ""identifier"": ""fq_Q4_2013_14"",
            ""label"": ""2013/14 Q4"",
            ""altLabel"": ""2013/14 Q4"",
            ""isSummary"": false
          },
          ""valueType"": {
            ""identifier"": ""raw"",
            ""label"": ""Raw value"",
            ""isSummary"": false
          }
        }
      ],
      ""rows"": [
        {
          ""values"": [
            {
              ""source"": 515.0,
              ""value"": 515.0,
              ""formatted"": ""515"",
              ""format"": ""#,##0"",
              ""publicationStatus"": ""Published""
            },
            {
              ""source"": 264.0,
              ""value"": 264.0,
              ""formatted"": ""264"",
              ""format"": ""#,##0"",
              ""publicationStatus"": ""Published""
            },
            {
              ""source"": 254.0,
              ""value"": 254.0,
              ""formatted"": ""254"",
              ""format"": ""#,##0"",
              ""publicationStatus"": ""Published""
            },
            {
              ""source"": 455.0,
              ""value"": 455.0,
              ""formatted"": ""455"",
              ""format"": ""#,##0"",
              ""publicationStatus"": ""Published""
            }
          ]
        }
      ]
    }";
    		
    	  Console.WriteLine("Begin JSON Deserialization\n");
    
          var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonString);
          var rows = rootObject.rows; 
    	  int rowCounter = 1;
    	  foreach (Row oneRow in rows)
    	  {
    		  Console.WriteLine("Row: " + rowCounter);
    		  int valueCounter = 1;
    		  foreach(Value oneValue in oneRow.values)
    		  {
    		  	Console.WriteLine("    Value: " + valueCounter);			  
    		  	Console.WriteLine("        source: " + oneValue.source);
    		  	Console.WriteLine("        value: " + oneValue.value);
    		  	Console.WriteLine("        formatted: " + oneValue.formatted);
    		  	Console.WriteLine("        publicationStatus: " + oneValue.publicationStatus);				  
    			valueCounter++;
    		  }
    		  rowCounter++;
    	  }
    					
    	  Console.WriteLine("\nEnd JSON Deserialization");
    
    }
    }
    
    public class Metadata
    {
        public List<string> columnGrouping { get; set; }
    }
    
    public class Area
    {
        public string identifier { get; set; }
        public string label { get; set; }
        public string altLabel { get; set; }
        public bool isSummary { get; set; }
    }
    
    public class MetricType
    {
        public string identifier { get; set; }
        public string label { get; set; }
        public string altLabel { get; set; }
        public bool isSummary { get; set; }
    }
    
    public class Period
    {
        public string identifier { get; set; }
        public string label { get; set; }
        public string altLabel { get; set; }
        public bool isSummary { get; set; }
    }
    
    public class ValueType
    {
        public string identifier { get; set; }
        public string label { get; set; }
        public bool isSummary { get; set; }
    }
    
    public class Column
    {
        public Area area { get; set; }
        public MetricType metricType { get; set; }
        public Period period { get; set; }
        public ValueType valueType { get; set; }
    }
    
    public class Value
    {
        public double source { get; set; }
        public double value { get; set; }
        public string formatted { get; set; }
        public string format { get; set; }
        public string publicationStatus { get; set; }
    }
    
    public class Row
    {
        public List<Value> values { get; set; }
    }
    
    public class RootObject
    {
        public Metadata metadata { get; set; }
        public List<Column> columns { get; set; }
        public List<Row> rows { get; set; }
    }
