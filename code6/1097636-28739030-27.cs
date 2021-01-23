		StandardKernel kernel = new StandardKernel();
		kernel.Bind<IValidationRule>().To<MyClass1>();
		kernel.Bind<IValidationRule>().To<MyClass2>();
		kernel.Bind<IValidationRuleCompositeConstr>().To<ValidationRuleCompositeOriginal>();
		IEnumerable<IValidationRule> rules = kernel.GetAll<IValidationRule>();
		Ninject.Parameters.ConstructorArgument therules = new Ninject.Parameters.ConstructorArgument("therules", rules);
			IValidationRuleCompositeConstr try2 = kernel.Get<IValidationRuleCompositeConstr>(therules);
			Debug.WriteLine("Second Class");
			Debug.WriteLine (string.Format("{0}",try2.IsValid()));
