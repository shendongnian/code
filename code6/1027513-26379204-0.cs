    public enum BinaryOperator
    {
      LessThenOrEqual,
      LessThen,
      Equal,
      GreaterThen,
      GreaterThenOrEqual
    }
    public class BinaryOperatorEvaluator
    {
      public BinaryOperatorEvaluator(BinaryOperator op)
      {
        Operator = op;
      }
      public BinaryOperator Operator { get; private set; }
      public bool Evaluate(IComparable x, IComparable y)
      {
        switch (Operator)
        {
          case BinaryOperator.Equal:
            return x.CompareTo(y) == 0;
          case BinaryOperator.GreaterThen:
            return x.CompareTo(y) > 0;
          case BinaryOperator.GreaterThenOrEqual:
            return x.CompareTo(y) >= 0;
          case BinaryOperator.LessThen:
            return x.CompareTo(y) < 0;
          case BinaryOperator.LessThenOrEqual:
            return x.CompareTo(y) <= 0;
          default:
            throw new NotImplementedException();
        }
      }
      public static BinaryOperatorEvaluator FromExpression(string expression, out int value)
      {
        var regexValidTerm = new Regex("^(?<operator>(<=|=|>=|<|>)?)(?<numeric>([0-9]+))$");
        var match = regexValidTerm.Match(expression);
        if (!match.Success)
        {
          throw new ArgumentException("Not a valid expression.", "expression");
        }
        var opValue = match.Groups["operator"].Value;
        var op = BinaryOperator.Equal;
        if (!string.IsNullOrEmpty(opValue))
        {
          switch(opValue)
          {
            case "<=":
              op = BinaryOperator.LessThenOrEqual;
              break;
            case "=":
              op = BinaryOperator.Equal;
              break;
            case ">=":
              op = BinaryOperator.GreaterThenOrEqual;
              break;
            case "<":
              op = BinaryOperator.LessThen;
              break;
            case ">":
              op = BinaryOperator.LessThenOrEqual;
              break;
            default:
              throw new NotImplementedException();
          }
        }
        value = int.Parse(match.Groups["numeric"].Value);
        return new BinaryOperatorEvaluator(op);
      }
    }
    int number;
    var bo = BinaryOperatorEvaluator.FromExpression("<=15", out number);
    // false
    var foo = bo.Evaluate(16, number);
    // true
    foo = bo.Evaluate(15, number);
    // also true
    foo = bo.Evaluate(14, number);
