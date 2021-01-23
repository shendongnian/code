    namespace Algorithms
    {
    	public class Automaat
    	{
    		public const char Epsilon = default(char);
    		private Graph current, valid;
    
    		public Automaat(string text)
    		{
    			Graph start = new Graph();
    			valid = new Graph();
    
    			current = start;
    
    			foreach (var letter in text)
    			{
    				var next = new Graph();
    				current.SetTransition(next, letter);
    				current = next;
    			}
    
    			valid = current;
    			current = start;
    		}
    
    		public void Input(char symbol)
    		{
    			if (current != null)
    				current = current.Next(symbol);
    		}
    
    		public bool IsValid()
    		{
    			return current == valid;
    		}
    
    
    		/// <summary>
    		/// Holds connections to other graphs, the position of that graph in the array relative to the alphabet determines what symbol that link uses.
    		/// </summary>
    		private class Graph
    		{
    			private static char[] alphabet;
    			Graph[] nodes;
    
    			public Graph()
    			{
    				nodes = new Graph[26];
    			}
    
    			public void SetTransition(Graph graph, char symbol)
    			{
    				nodes[ConvertToIndex(symbol)] = graph;
    			}
    
    			public Graph Next(char symbol)
    			{
    				return nodes[ConvertToIndex(symbol)];
    			}
    
    			private int ConvertToIndex(char symbol)
    			{
    				return symbol - 'a';
    			}
    		}
    	}
    }
