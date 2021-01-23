	// Create a data structure to model the deductions themselves
	public class LineItemDeduction
	{
		public decimal UnitPriceAmount { get; set; }
		public decimal UnitPricePercentage { get; set; }
		public decimal LinePriceAmount { get; set; }
		public decimal LinePricePercentage { get; set; }
		
		// Assumed that waivers are distinct and are not composed together, only applied on the listed price.
		public decimal CalculateWaivedPrice(decimal unitPrice, int qty)
		{
			return ((unitPrice - UnitPriceAmount - (unitPrice * UnitPricePercentage)) * qty) - LinePriceAmount - (unitPrice * qty * LinePricePercentage);
		}
	}
	// Calculate the deductions
    private LineItemDeduction CalculateLineItemDeductionStrategy(LineItemDeduction deduction, Waiver waiver)
	{
		switch (waiver.Type) { 
          case 1111:
           deduction.UnitPriceAmount += waiver.Amount;
           break;
          case 2222:
           deduction.UnitPricePercentage += waiver.Amount;
           break;
          case 3333:
           deduction.LinePriceAmount += waiver.Amount;
           break;
          case 4444:
           deduction.LinePricePercentage += waiver.Amount;
           break;
         }
		 
		 return deduction;
	}
	
	// Extension method only for LineItem but it's the same principle for order waivers
	public static decimal GetWaivedPrice(this IEnumerable<Waiver> waivers, decimal unitPrice, int qty, Func<LineItemDeduction, Waiver, LineItemDeduction> deductionStrategy)
	{
		return waivers.Aggregate(
			new LineItemDeduction(),
			deductionStrategy,
			d => d.CalculateWaivedPrice(unitPrice, qty)
		);
	}
	
	// Now to get the waived price
	var waivedPrice = waivers.GetWaivedPrice(unitPrice, qty, CalculateLineItemDeductionStrategy);
