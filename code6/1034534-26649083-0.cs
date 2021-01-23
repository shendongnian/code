    // Create Two Classes
	public class Employee
	{
	   public int Id;
	   public string Name;
	   public double Salary;
	   public DateTime BoD; 
	}
	public class EmployeeIDAndSalary
	{
	   public int Id;
	   public double Salary;
	}
    // Create Extension Function
    // We need to use Automapper extension library. 
    // Install Automapper using Nuget Package Manager. And create a class and add this code in it.
	namespace Models.Mapper
	{
		public static class EmployeeMapper
		{
			public static Employee MapToEmployee(this EmployeeIDAndSalary obj)
			{ 
				if (obj != null)
				{
					Employee model = AutoMapper.TryAutoMap<Employee>(obj);                
					return model ;
				}
				return new Employee();
			}
			public static IEnumerable<Employee> MapToEmployee(this IEnumerable<EmployeeIDAndSalary> obj)
			{
				if (obj != null)
				{
					return obj.Select(x => x.ConvertToEmployee()).AsEnumerable();
				}
				return new List<Models.Employee>();
			}
		}
	    
		public static class AutoMapper
		{
			static AutoMapper()
			{
	          
			}
	        
			public static T TryAutoMap<T>(object fromObject)
			{
				try
				{
					var currentObj = Activator.CreateInstance<T>();
					var type = currentObj.GetType();
					var propInfo = type.GetProperties();
					var _type = fromObject.GetType();
					foreach (var item in _type.GetProperties())
					{
						var prop = propInfo.Where(c => c.Name == item.Name).FirstOrDefault();
						if (prop != null)
						{
						   // if (prop.GetType().IsAssignableFrom(item.GetType()))
							{
								if (IsGenericEnumerable(item.PropertyType))
								{
									continue;
								}
	                            
								if (prop.GetType() == item.GetType())
								{
									try
									{
										prop.SetValue(currentObj, item.GetValue(fromObject, null), null);
									}
									catch { }
								}
							}
						}
					}
					return currentObj;
				}
				catch
				{
					return default(T);
				}
			}
			private static bool IsClass(Type type)
			{            
				return type.IsClass && !type.IsPrimitive;
			}
	        
			private static bool IsGenericEnumerable(Type type)
			{
				if (type.FullName.ToLower().Contains("datamodel") || type.FullName.ToLower().Contains("models") || type.FullName.ToLower().Contains("collection"))
				{
					return true;
				}
				return false;
			}
		}
	}
    // Use Namespace -> Models.Mapper.EmployeeMapper;
    // Execute your procedure using EmployeeIdAndSalary
	try
	{
		var _objList = context.SqlQuery<EmployeeIDAndSalary>("YourProcedureName @SpParameterName", param).ToList().MapToEmployee();
	}
	catch
	{ }
    // I think this is all what you need.
