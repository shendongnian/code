    public abstract class BaseExpression
    {
    }
    public class VariableExpression : BaseExpression
    {
       public string Var {get; set;}
       public int Exponent {get; set;}
    }
    public class ConstExpression : BaseExpression
    {
       public object Val {get; set;}
    }
    public class BinExpression : BaseExpression
    {
       public BaseExpression Left { get; set; }
       public BaseExpression Right { get; set; }
       public string Operator { get; set; }
    }
