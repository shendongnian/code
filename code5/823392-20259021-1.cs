    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Employee
    {
    	public int Id {get; set;}
    	public string FirstName { get; set;}
    	public string LastName {get; set;}
    }
    
    public class Test
    {
    	private static string[] GetColumnValues(Employee emp, params int[] cols)
    	{
    		var props = emp.GetType().GetProperties();
    		var values = new List<string>();
    		foreach(var i in cols)
    		{
    			if (i >= 0 && i < props.Length)
    			{
    				object value = props[i].GetValue(emp, null);
    				values.Add(value == null ? string.Empty : value.ToString());
    			}
    		}
    		return values.ToArray();
    	}
    	public static void Main()
    	{
    	    var emp = new Employee() { Id = 1, FirstName = "John", LastName = "Smith" };
    	    var values = GetColumnValues(emp, 0, 2);
    	    Console.WriteLine(string.Join("\t", values));
    	}
    }
