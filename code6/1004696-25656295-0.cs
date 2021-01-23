    public static class Assert
    {
    	public static void AreEqual(object expected, object actual) { }
    	public static void AreEqual<T>(T expected, T actual) where T : IEquatable<T> { }
    }
    
    class Bar { } 
