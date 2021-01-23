    public class Franchise 
    {
       public string FolderName { get; set; }
       public string InstallerExeName { get; set; }
        		
       bool ValidateProperty(string propertyName) {
      	 var allFranchises = new List<Franchise>();
    	 var parameter = Expression.Parameter(typeof(Franchise));
    	 var property = Expression.Property(parameter, propertyName);
    	 var thisExpression = Expression.Constant(this, typeof(Franchise));
    	 var value = Expression.Property(thisExpression, propertyName);
    	 var notThis = Expression.ReferenceNotEqual(thisExpression, property);
    	 var equal = Expression.Equal(value, property);
    	 var lambda = Expression.Lambda<Func<Franchise, bool>>(Expression.And(notThis, equal));
    	
 
         // lamda is now the equivalent of:
         // x => !object.ReferenceEquals(this, x) && object.Equals(x.Property, this.Property)	  
         return allFranchises.Any(lambda.Compile());
       }
    }
