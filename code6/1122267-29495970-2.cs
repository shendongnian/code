    System.Object, System.ValueType, System.Array, System.Enum, System.Delegate
    System.Exception, System.Type, System.Attribute
    
    System.SByte, System.Byte, System.Int16, System.UInt16, System.Int32, System.UInt32, System.Int64, System.UInt64, System.Char, System.Single, System.Double, System.Decimal, System.Boolean, System.Object, System.String 
    
    System.MulticastDelegate (not sure)
    System.Void
    System.IDisposable 
    System.Nullable<T>
    System.Linq.Expressions.Expression<D>, 
    System.Collections.Generic.IList<T> (implicit cast from System.Array, not sure)
    System.Threading.Tasks.Task (for async/await)
    System.Threading.Tasks.Task<T> (for async/await)
    System.Runtime.CompilerServices.INotifyCompletion (for async/await)
    System.Runtime.CompilerServices.ICriticalNotifyCompletion (for async/await)
    System.Action (for await, resumption delegate)
    System.Collections.IEnumerable (for collection initializer and foreach)
    System.Collections.IEnumerable<T> (for foreach)
    System.Threading.Monitor (for lock)
    System.IntPtr/System.UIntPtr (specific type for volatile fields)
    
    // These attribute are directly recognized by C#
    System.AttributeUsageAttribute 
    System.Diagnostics.ConditionalAttribute 
    System.ObsoleteAttribute 
    System.Runtime.CompilerServices.CallerLineNumberAttribute
    System.Runtime.CompilerServices.CallerFilePathAttribute
    System.Runtime.CompilerServices.CallerMemberNameAttribute 
    System.Runtime.CompilerServices.CSharp.IndexerNameAttribute
    
    // These exceptions seems to be "important" for C#
    System.OverflowException
    System.InvalidOperationException 
    System.NullReferenceException 
    System.OutOfMemoryException 
    System.DivideByZeroException 
    System.ArrayTypeMismatchException 
    System.ArithmeticException 
    System.TypeInitializationException
    System.IndexOutOfRangeException
    System.StackOverflowException
