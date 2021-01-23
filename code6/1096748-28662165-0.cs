	public static void Main()		
	{
		var original = new TestEntity();
		original.Name = "test";
		
		var dto = new TestDTO();
		dto.FirstName = "New Value";
		
		UpdateIfDifferent(original, o => o.Name, dto, d => d.FirstName);
		
		Console.WriteLine(original.Name);
	}
	
	private static void UpdateIfDifferent<TOriginal, TOriginalProperty, TUpdated, TUpdatedProperty>
  		(TOriginal original, Expression<Func<TOriginal, TOriginalProperty>> originalProperty, 
			TUpdated updated, Expression<Func<TUpdated, TUpdatedProperty>> updatedProperty)
  	{
      if (!originalProperty.Compile()(original).Equals(updatedProperty.Compile()(updated)))  
	  {
		    var updatedMember = (updatedProperty.Body as MemberExpression).Member as PropertyInfo;
		  	var updatedValue = updatedMember.GetValue(updated);
		    var member = (originalProperty.Body as MemberExpression).Member as PropertyInfo;
		  	member.SetValue(original, updatedValue);
	  
        }
    }
	
	public class TestEntity
	{
		public string Name {get;set;}
	}
	
	public class TestDTO
	{
		public string FirstName {get;set;}
	}
    
