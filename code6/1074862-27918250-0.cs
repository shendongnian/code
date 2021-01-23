    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	public static void Main()
	{
	
		List<string> lstString = new List<string>();
		lstString.Add("Project.Beta.Version.Rule");		
		lstString.Add("Project.Program.Table");
		lstString.Add("Project.Program");
		lstString.Add("Zip.File");
		
		var root = new RfClass();
		
		foreach(var x in lstString)
		{
			string[] words = x.Split('.');
			CreateTree(root, words, 0);
		}
		
		Display(root);
	}	
	
	public static void CreateTree(RfClass root, string[] words, int idx)
	{
		RfClass next;
		if (false == root.lstRefClass.TryGetValue(words[idx], out next))
		{
			next = new RfClass();
			root.lstRefClass.Add(words[idx], next);
		}
		if (idx + 1 < words.Length)
			CreateTree(next, words, idx + 1);
	}
	
	public static void Display(RfClass root, int indent = 0)
	{
		foreach(var p in root.lstRefClass)
		{
			Console.WriteLine("{0} key: {1} ",new string('\t', indent), p.Key);
			Console.WriteLine("{0} Value: Dictionary<string, RfClass>", new string('\t', indent));
			Display(p.Value, indent+1);
		}
	}
	
	public class RfClass
	{
	   public Dictionary<string, RfClass> lstRefClass = new Dictionary<string, RfClass>();
	}
    }
