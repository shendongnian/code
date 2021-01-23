    public class MyClass
    {
       public int MyProperty {get;set;}
    }
    
    ...
    
    var obj = new MyClass {MyProperty = 123}; // obj is MyClass
    Expression<Func<Customer, bool>> e1 = DynamicExpression.ParseLambda<Customer, bool>("Age = @0.MyProp", obj);
