    using System.Collections.ObjectModel;
	public class Entity<TPrimKey>
	{
		public TPrimKey Key { get; set; }
	}
	public class Entities<TPrimKey> : KeyedCollection<TPrimKey, Entity<TPrimKey>>
	{
		protected override TPrimKey GetKeyForItem( Entity<TPrimKey> item )
		{ return item.Key; }
	}
	public class MyEntity1 : Entity<int>
	{
	}
	public class MyEntity2 : Entity<int>
	{
	}
	public class MyEntities : Entities<int>
	{
		public static void Test()
		{
			var entities = new MyEntities();
			var entity1 = new MyEntity1();
			entities.Add( entity1 );
			var entity2 = new MyEntity2();
			entities.Add( entity1 );
		}
	}
