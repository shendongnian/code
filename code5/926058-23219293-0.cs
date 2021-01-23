	public struct IfStatement {
		public IfStatement (string statement, string comparison, string conditionValue, string ifCondition_True, string ifCondition_False) {
			Statement = statement;
			Comparison = comparison;
			ConditionValue = conditionValue;
			IfCondition_True = ifCondition_True;
			IfCondition_False = ifCondition_False;
		}
		
		public string Statement { get; private set; }
		public string Comparison { get; private set; }
		public string ConditionValue { get; private set; }
		public string IfCondition_True { get; private set; }
		public string IfCondition_False { get; private set; }
	}
	
