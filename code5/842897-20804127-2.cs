    public abstract class BaseUnit
    {
        public static int UnitCost { get { return 10; } }
    }
    public class CheapUnit : BaseUnit
    {
        new public static int UnitCost { get { return 5; } }
    }
    public class ExpensiveUnit : BaseUnit
    {
        new public static int UnitCost { get { return 20; } }
    }
    public class MultipleUnit : BaseUnit
    {
        new public static int UnitCost { get { return BaseUnit.UnitCost * 4; } }
    }
