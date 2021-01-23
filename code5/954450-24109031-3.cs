    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Node center = new Node { Name = "In House" };
    		Node north = new Node { Name = "North of House" };
    		Node west = new Node { Name = "Front of House" };
    		Node east = new Node { Name = "Back of House" };
    		Node south = new Node { Name = "South of House" };
    		
    		center.East = east;
    		east.West = center;
    		
    		center.West = west;
    		west.East = center;
    		
    		east.North = north;
    		north.East = east;
    		
    		east.South = south;
    		south.East = east;
    		
    		south.West = west;
    		west.South = south;
    		
    		west.North = north;
    		north.West = west;
    			
    		DumpNodes(center);
    		
    		Console.WriteLine();
    		
    		JsonSerializerSettings settings = new JsonSerializerSettings();
    		settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
    		settings.NullValueHandling = NullValueHandling.Ignore;
    		settings.Formatting = Formatting.Indented;
    		
    		string json = JsonConvert.SerializeObject(center, settings);
    		Console.WriteLine(json);
    		
    		Node node = JsonConvert.DeserializeObject<Node>(json, settings);
    		
    		Console.WriteLine();
    
    		DumpNodes(node);
    	}
    	
    	private static void DumpNodes(Node startingNode)
    	{
    		HashSet<Node> seen = new HashSet<Node>();
    		List<Node> queue = new List<Node>();
    		queue.Add(startingNode);
    		while (queue.Count > 0)
    		{
    			Node node = queue[0];
    			queue.RemoveAt(0);
    			if (!seen.Contains(node))
    			{
    				seen.Add(node);
    				Console.WriteLine(node.Name);
    				Look("north", node.North, queue, seen);
    				Look("west", node.West, queue, seen);
    				Look("east", node.East, queue, seen);
    				Look("south", node.South, queue, seen);
    			}
    		}
    	}
    	
    	private static void Look(string dir, Node node, List<Node> queue, HashSet<Node> seen)
    	{
    		if (node != null)
    		{
    			Console.WriteLine("   " + dir + ": " + node.Name);
    			if (!seen.Contains(node))
    			{
    				queue.Add(node);
    			}
    		}
    	}
    }
    
    public class Node
    {
    	public string Name { get; set; }
    	public Node North { get; set; }
        public Node South { get; set; }
        public Node East { get; set; }
        public Node West { get; set; }
    }
