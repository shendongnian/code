    public class TestCreateOperator: CellOperator, CreateOperator<Cell> {
      public bool CanCreate(NameMatcher memberName, Tree<Cell> parameters) {
        return memberName.Matches("testname");
      }
      public TypedValue Create(NameMatcher memberName, Tree<Cell> parameters) {
        return new TypedValue("mytestname");
      }
    }
