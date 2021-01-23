    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var setOfPersons = new List<List<Person>>();
    
    		var firstPersonList=new List<Person>();
    		Person p1=new Person(100,"James");
    		Person p2=new Person(200,"Smith");
    		firstPersonList.Add(p1);
    		firstPersonList.Add(p2);
    		
    		setOfPersons.Add(firstPersonList);
    		
    		List<Person> secondPersonList=new List<Person>();
    		Person p3=new Person(100,"James");
    		Person p4=new Person(200,"Smith");
    		Person p5=new Person(300,"Thomas");
    		secondPersonList.Add(p3);
    		secondPersonList.Add(p4);
    		secondPersonList.Add(p5);
    		
    		setOfPersons.Add(secondPersonList);
    		
    		List<Person> thirdPersonList=new List<Person>();
    		Person p6=new Person(100,"James");
    		Person p7=new Person(400,"Amy");
    		thirdPersonList.Add(p6);
    		thirdPersonList.Add(p7);
    		
    		setOfPersons.Add(thirdPersonList);
    		
    		var c = GetPersonCountDictionary(setOfPersons);
    		
    		var commonPersons = (from k in c.Keys where c[k].Count == setOfPersons.Count() select c[k].Person).ToList();
    
    		
    		foreach(var p in commonPersons) {
    			Console.WriteLine(p.Name);
    		}
    		
    	}
    	
    	public static Dictionary<string, PersonCount> GetPersonCountDictionary(List<List<Person>> setOfPersons) {
    		var c = new Dictionary<string, PersonCount>();
    		foreach(var pl in setOfPersons) {
    			foreach(var p in pl) {
    				var count = c.ContainsKey(p.Name) ? c[p.Name].Count + 1 : 1;
    				
    				if (c.ContainsKey(p.Name))
    					c[p.Name].Count = count;
    				else
    					c[p.Name] = new PersonCount(p, count);
    			}
    		}
    		return c;
    	}
    }
    
    public class PersonCount {
    	public PersonCount(Person person, int count) {
    		Person = person;
    		Count = count;
    	}
    	
    	public Person Person { get; set; }
    	public int Count { get; set; }
    }
    
    public class Person {
    	public Person(int id, string name) {
    		Id = id;
    		Name = name;
    	}
    	
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
