    // 3. "Static" Reflection
    public void UseStaticReflection(){
    	Car car = new Car();
    	car.SetProperty(c => c.Break, "diskBreak");
    	Console.WriteLine (car.Break);
    }
    
    public static class PropExtensions{
    	public static void SetProperty<T, TProp>(this T obj, Expression<Func<T, TProp>> propGetter, TProp value){		
    		var propName = ((MemberExpression)propGetter.Body).Member.Name;
    		obj.GetType().GetProperty(propName).SetValue(obj, value);
    	} 
    }
