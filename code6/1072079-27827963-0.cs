    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Test
    {
    	public static void Main()
	    {
    		List<Fruit> f = new List<Fruit>();
    		Fruit fTemp = new Fruit() { name = "Kiwi" };
    		f.Add(fTemp);
    		fTemp = new Fruit() { name = "Tomato" };
    		f.Add(fTemp);
    		
    		List<Veg> v = new List<Veg>();
    		Veg vTemp = new Veg() { name = "Tomato" };
    		v.Add(vTemp);
    		
    		List<Veg> vDuplicates = v.Where(vegToCompare=>f.Any(fruitToCompare=>fruitToCompare.name.Equals(vegToCompare.name))).ToList();
    		vDuplicates.ForEach(a=>Console.WriteLine(a.name));
    		Console.WriteLine("Number of Duplicates Found: " + vDuplicates.Count);
	    }
    }
    public class Fruit
    {
    	public string name;
    }
    
    public class Veg
    {
    	public string name;
    }
