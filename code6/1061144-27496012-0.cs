    public abstract class PredicateExpression<T> {
      private Expression<Func<T, bool>> predicate;
      protected PredicateExpression(Expression<Func<T, bool>> predicate) {
        this.predicate = predicate;
      }
      public Expression<Func<T, bool>> Predicate {
        get { return predicate; } 
      }
    }
    public class SinglePredicateExpression<T> : PredicateExpression<T> {
      public SinglePredicateExpression(Expression<Func<T, bool>> predicate) : base(predicate) {} 
    }
    public class MultiPredicateExpression<T> : PredicateExpression<T> {
      public MultiPredicateExpression(Expression<Func<T, bool>> predicate) : base(predicate) {}
      public static implicit operator MultiPredicateExpression<T>(Expression<Func<T, bool>> predicate) {
        return new MultiPredicateExpression<T>(predicate);
      }
    }
