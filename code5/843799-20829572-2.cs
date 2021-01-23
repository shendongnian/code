	public class CalculationPair<TEntityType, TProperty>
		where TEntityType : class
		where TProperty : struct
	{
        // not sure that first three properties are needed here
		public ValueTypeProperty<TEntityType, TProperty> Left { get; set; }
		public Operand Operand { get; set; }
		public ValueTypeProperty<TEntityType, TProperty> Right { get; set; }
        // closure method
		public Func<TEntityType, TProperty> Calculator { get; set; }
    }
