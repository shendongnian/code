	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	namespace UnitTestProject1
	{
		[TestClass]
		public class CheckFindDerivedItemsAndCallForEachT
		{
			[TestMethod]
			public void TestMethod1()
			{
				var list = new List<BaseItem>();
				list.Add(new DerivedItem<string>());
				list.Add(new DerivedItem<int>());
				var test = new Test();
				test.FindDerivedItemsAndCallForEachT(list);
			}
		}
		public class BaseItem
		{
		}
		public class DerivedItem<T> : BaseItem
		{
		}
		public class Test
		{
			public void FindDerivedItemsAndCallForEachT(List<BaseItem> list)
			{
				var derivedItems = from d in list
								   where d.GetType().IsGenericType
								   && d.GetType().GetGenericTypeDefinition() == typeof(DerivedItem<>)
								   select d;
				var listsOfDerivedItems = from d in derivedItems
										  group d by d.GetType() into g
										  select g.ToList();
				// create generic type definition for lists
				var listGenericDefinition = typeof(List<>);
				foreach (var listOfDerivedItem in listsOfDerivedItems)
				{
					// all the lists should have at least one member which will be of the type that we need.
					Type itemType = listOfDerivedItem[0].GetType();
					Type listType = listGenericDefinition.MakeGenericType(itemType);
					// note use of dynamic is important.
					dynamic castList = Activator.CreateInstance(listType);
					foreach (dynamic item in listOfDerivedItem)
					{
						castList.Add(item);
					}
					HandleForTypeT(castList);
				}
			}
			public void HandleForTypeT<T>(List<DerivedItem<T>> derivedList)
			{
				// do something with the provided list.
			}
		}
	}
