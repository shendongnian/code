    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication
    	{
    	public class Class1
    		{
    		public static string CSVInput = @"12-34-4567,12345 
    12-34-4567,12345
    12-34-4567,12345 
    12-34-4567,12345 
    12-34-4567,12345 
    12-34-4567,12345";
    
    		public static void Main(string[] args)
    			{
    			var orders = GetOrdersFromCSV(CSVInput);
    			string xml = ConvertToXDocument(orders).ToString();
    			Console.WriteLine(xml);
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    			}
    
    		public static List<Order> GetOrdersFromCSV(string csv)
    			{
    			//This should be a good place to use FileHelpers, but since the format is so simple we're going to parse it ourselves instead.
    			string[] lines = csv.Replace("\r\n", "\n").Split('\n');
    			List<Order> orders = new List<Order>();
    			foreach (string line in lines)
    				{
    				Order order = new Order();
    				order.OrderNumber = line.Split(',')[0]; //get first column
    				order.ProductId = line.Split(',')[1]; //get second column
    				orders.Add(order);
    				}
    			return orders;
    			}
    		public static XDocument ConvertToXDocument(List<Order> orders)
    			{
    			XDocument doc =
    	  new XDocument(
    		new XElement("Orders",
    			orders.Select(o => new XElement("Order", new XAttribute("OrderNo", o.OrderNumber), new XAttribute("ProductId", o.ProductId)))));
    			return doc;
    			}
    		}
    	public class Order
    		{
    		public string OrderNumber { get; set; }
    		public string ProductId { get; set; }
    		}
    
    	}
