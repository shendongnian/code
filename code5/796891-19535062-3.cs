		public static void CastleConfig(IWindsorContainer container){
			var config = new Config();
		    container.Register(
                Component.For<IObjectConstructionTask>().ImplementedBy<LimitByTemplateTask>(),
                );
			container.Install(new SitecoreInstaller(config));
		}
