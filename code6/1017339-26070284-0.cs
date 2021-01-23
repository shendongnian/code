    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"
                {
                    ""status"": ""success"",
                    ""result"": {
                        ""identity_document"": {
                            ""number"": ""xx"",
                            ""type"": ""02"",
                            ""country_of_issue"": ""ZA""
                        },
                        ""person"": {
                            ""surname"": ""xx"",
                            ""initials"": ""xx"",
                            ""driver_restrictions"": [
                                ""0"",
                                ""0""
                            ],
                            ""date_of_birth"": ""05/11/1939"",
                            ""preferred_language"": """",
                            ""gender"": ""FEMALE""
                        },
                        ""driving_license"": {
                            ""certificate_number"": ""xx"",
                            ""country_of_issue"": ""ZA""
                        },
                        ""card"": {
                            ""issue_number"": ""02"",
                            ""date_valid_from"": ""19/05/2001"",
                            ""date_valid_until"": ""19/05/2006""
                        },
                        ""professional_driving_permit"": ""nil"",
                        ""vehicle_classes"": [
                            {
                                ""code"": ""EB"",
                                ""vehicle_restriction"": ""0"",
                                ""first_issue_date"": ""18/05/2001""
                            }
                        ],
                        ""photo"": ""xxx""
                    }
                }";
    		
    		var root = JsonConvert.DeserializeObject<MyType>(json);
    		
    		Console.WriteLine("ID doc number: " + root.result.identity_document.number);
    		Console.WriteLine("ID doc type: " + root.result.identity_document.type);
    		Console.WriteLine("ID doc country: " + root.result.identity_document.country_of_issue);
    		Console.WriteLine("person surname: " + root.result.person.surname);
    		Console.WriteLine("person DOB: " + root.result.person.date_of_birth);
    		Console.WriteLine("person gender: " + root.result.person.gender);
    		Console.WriteLine("D.L. cert number: " + root.result.driving_license.certificate_number);
    		Console.WriteLine("card valid from: " + root.result.card.date_valid_from);
    		Console.WriteLine("card valid to: " + root.result.card.date_valid_until);
    		Console.WriteLine("vehicle class code: " + root.result.vehicle_classes.First().code);
    		Console.WriteLine("photo: " + root.result.photo);
    	}
    }
    
    public class MyType
    {
    	public string status { get; set; }
    	public Result result { get; set; }
    	
    	[JsonConstructor]
    	public MyType()
    	{ }
    	
    	public MyType(string aStatus, Result aResult)
    	{
    		this.status = aStatus;
    		this.result = aResult;
    	}
    }
    
    public class Result
    {
    	public IdentityDocument identity_document { get; set; }
    	public Person person { get; set; }
    	public DrivingLicense driving_license { get; set; }
    	public Card card { get; set; }
    	public string professional_driving_permit { get; set; }
    	public List<VehicleClass> vehicle_classes { get; set; }
    	public string photo { get; set; }
    }
    
    public class IdentityDocument
    {
    	public string number { get; set; }
    	public string type { get; set; }
    	public string country_of_issue { get; set; }
    }
    
    public class Person
    {
    	public string surname { get; set; }
    	public string initials { get; set; }
    	public List<string> driver_restrictions { get; set; }
    	public string date_of_birth { get; set; }
    	public string preferred_language { get; set; }
    	public string gender { get; set; }
    }
    
    public class DrivingLicense
    {
    	public string certificate_number { get; set; }
    	public string country_of_issue { get; set; }
    }
    
    public class Card
    {
    	public string issue_number { get; set; }
    	public string date_valid_from { get; set; }
    	public string date_valid_until { get; set; }
    }
    
    public class VehicleClass
    {
    	public string code { get; set; }
    	public string vehicle_restriction { get; set; }
    	public string first_issue_date { get; set; }
    }
