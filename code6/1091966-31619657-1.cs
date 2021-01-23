	//Register all IJob implementations that are not generic, abstract nor decorators
	Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "SomeFilter*.dll")
	.Select(file => Assembly.LoadFile(file))
	.ForEach(s =>
	{
		s.GetTypes()
			.Where(type => typeof(IJob).IsAssignableFrom(type) && (!type.IsAbstract && !type.IsGenericTypeDefinition))
			.Select(type => new { type, ctor = type.GetConstructors().Any(ct => ct.GetParameters().Any(p => p.ParameterType == typeof(IJob))) == false })
			.Select(type => type.type)
			.ForEach<Type>(o =>
			{
				string jobFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}.xml", Path.GetFileNameWithoutExtension(o.Assembly.Location)));
				var typeLoadHelper = new SimpleTypeLoadHelper();
				typeLoadHelper.Initialize();
				XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(typeLoadHelper);
				processor.AddJobGroupToNeverDelete("XMLSchedulingDataProcessorPlugin");
				processor.AddTriggerGroupToNeverDelete("XMLSchedulingDataProcessorPlugin");
				processor.ProcessFileAndScheduleJobs(jobFile, jobFile, this.Scheduler);
			});
	});
