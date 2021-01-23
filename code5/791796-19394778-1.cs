    using System;
    using System.Reflection;
    
    public class Test
    {
    	public class Employee
    	{
    		public String Name{get;set;}
    		public int Age{get;set;}
    		public int Salary{get;set;}
    	}
    	public static void Main()
    	{
    		Employee e1 = new Employee{Name="Old", Age=20, Salary=1000};
    		Employee e2 = new Employee{Age=30, Salary=5000};
    		
    		Copy(e2, e1);
    		
    		Console.WriteLine(e1.Name+" "+ e1.Age+" "+e1.Salary );
    	}
    	
        public static void Copy<T>(T from, T to)
        {
            Type t = typeof (T);
            PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in props) {
                if (!p.CanRead || !p.CanWrite) continue;
                object val = p.GetGetMethod().Invoke(from, null);
                object defaultVal = p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;
                if (null != defaultVal && !val.Equals(defaultVal)) {
                    p.GetSetMethod().Invoke(to, new[] {val});
                }
            }
        }
    }
