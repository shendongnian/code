		IEnumerable<IValidationRule> rules = kernel.GetAll<IValidationRule>();
		Ninject.Parameters.ConstructorArgument therules = new Ninject.Parameters.ConstructorArgument("therules", rules);
			IValidationRuleCompositeConstr try2 = kernel.Get<IValidationRuleCompositeConstr>(therules);
			Debug.WriteLine("Second Class");
			Debug.WriteLine (string.Format("{0}",try2.IsValid()));
