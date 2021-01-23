    static class GameObjectUtils{
        public bool DoOn<T>(this GameObject gameObject, Action<T> action)
        where T: class
        {
            var item = gameObject.GetComponent<T>();
            if(item==null)
            	return false;
            action(item);
            return true;
            }
		public bool DoOn<T1, T2>(this GameObject gameObject, Action<T1, T2> action)
			where T1:class where T2: class
		{
			var item1 = gameObject.GetComponent<T1>();
			if(item1==null)
				return false;
			var item2 = gameObject.GetComponent<T2>();
			if(item1==null)
				return false;
			action(item1, item2);
            return true;
            }
            public bool DoOn<T1, T2, T3>(this GameObject gameObject, Action<T1, T2, T3> action)
            where T1: class 
            where T2: class
            where T3: class
            {
            var item1 = gameObject.GetComponent<T1>();
            if(item1==null)
            	return false;
            var item2 = gameObject.GetComponent<T2>();
            if(item2==null)
            	return false;
            var item3 = gameObject.GetComponent<T3>();
            if(item3==null)
            	return false;
            action(item1, item2, item3);
            return true;
            }
            }
	
            class Circle{} class Square{} class Human { }
            class Program
            {
		
            public static void Main(string[] args)
            {
            GameObject go = new GameObject();
            go.DoOn((Circle c, Square sq, Human h) =>Console.WriteLine("called"));
            }
        }
     }
    
