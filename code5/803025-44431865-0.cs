    using System;
						
	public class Program
	{
		public static void Main()
		{
			var p = new MyProduct();
			p.Name = "test";
			Console.WriteLine(p.GetName());
		}
	}
	
	
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Foo { get; set; }
	}
	public class Variant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Bar { get; set; }
	}
	
	public class MyProduct: Product, IType {
	}
	
	public class MyVariant: Variant, IType {
	}
	
	
	public static class Extensions {
		public static string GetName(this IType type){
			return type.Name;
		}
	}
	
	public interface IType {
		string Name {get; set; }
	}
