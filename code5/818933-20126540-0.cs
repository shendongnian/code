    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			SortedDictionary<int, Game> gameConsoles = new SortedDictionary<int, Game>();
    
    			gameConsoles.Add(101, new Game("Playstation 4", 101));
    			gameConsoles.Add(108, new Game("Xbox 1", 108));
    			gameConsoles.Add(110, new Game("PS Vita", 110));
    			gameConsoles.Add(104, new Game("Wii U", 104));
    			gameConsoles.Add(102, new Game("3DS", 102));
    
    			foreach (KeyValuePair<int, Game> item in gameConsoles)
    			{
    				Console.WriteLine(item.Value.ToString());
    			}
    
    			Console.ReadKey();
    		}
    	}
    
    	public class Game
    	{
    		public Game(string name, int id)
    		{
    			Id = id;
    			Name = name;
    		}
    
    		public int Id { get; set; }
    		public string Name { get; set; }
    
    		public override string ToString()
    		{
    			return string.Format("Id: {0} Name: {1}", Id, Name);
    		}
    	}
    }
