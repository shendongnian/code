    internal class A
    {
         public int X;
    }
    
    private void test()
    {
         A[] Collection = new A[2];
         Collection[0].X = 1;
           CopyPropertyValues(Collection[0],Collection[1]);
         Collection[0] = new A();
         Collection[0].X = 2;
         
    }
    
    
    
    
    public static void CopyPropertyValues(object source, object destination)
    {
        var destProperties = destination.GetType().GetProperties();
    
        foreach (var sourceProperty in source.GetType().GetProperties())
        {
            foreach (var destProperty in destProperties)
            {
                if (destProperty.Name == sourceProperty.Name && 
            destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                {
                    destProperty.SetValue(destination, sourceProperty.GetValue(
                        source, new object[] { }), new object[] { });
    
                    break;
                }
            }
        }
    }
