    public class UserProp
    {
       public string Name { get; set; }
       public bool IsSet { get; set; }
    }
    public class UserProp<T> : UserProp
    {
       private T val;
       public T Value...
    }
