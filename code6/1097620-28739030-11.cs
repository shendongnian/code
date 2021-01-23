			StandardKernel kernel = new StandardKernel();
			kernel.Bind<IValidationRule>().To<MyClass1>();
			kernel.Bind<IValidationRule>().To<MyClass2>();
			kernel.Bind<IValidationRuleComposite>().To<ValidationRuleComposite>();
			
			IValidationRuleComposite try1 = kernel.Get<IValidationRuleComposite>();
			
			IEnumerable<IValidationRule> rules = kernel.GetAll<IValidationRule>();
			foreach(IValidationRule trycomp in rules)
				{ Debug.WriteLine("trycomp: " + trycomp.GetType().ToString()); trycomp.IsValid(); };
			
			try1.ValidationRuleCompose(rules.ToList());
			Console.WriteLine("{0}",try1.IsValid());
			Debug.WriteLine("try1: " + try1.GetType().ToString());
		
