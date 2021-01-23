    using System.Collections.ObjectModel;
	public interface IEntity<TPrimKey>
	{
		TPrimKey Key { get; set; }
	}
	public class Entities<TPrimKey> : KeyedCollection<TPrimKey, IEntity<TPrimKey>>
	{
		protected override TPrimKey GetKeyForItem( IEntity<TPrimKey> item )
		{ return item.Key; }
	}
	public class EntityA<TPrimKey> : IEntity<TPrimKey>
	{
		public TPrimKey Key { get; set; }
	}
	public class MyEntityA1 : EntityA<int>
	{
	}
	public class MyEntityA2 : EntityA<int>
	{
	}
	public class EntityB<TPrimKey> : IEntity<TPrimKey>
	{
		public TPrimKey Key { get; set; }
	}
	public class MyEntityB1 : EntityB<int>
	{
	}
	public class MyEntities : Entities<int>
	{
		public static void Test()
		{
			var entities = new MyEntities();
			var entityA1 = new MyEntityA1();
			entities.Add( entityA1 );
			var entityA2 = new MyEntityA2();
			entities.Add( entityA2 );
			var entityB1 = new MyEntityB1();
			entities.Add( entityB1 );
		}
	}
