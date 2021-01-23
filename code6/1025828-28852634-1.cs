            Assembly nodaTimeAssembly = typeof(LocalDate).GetTypeInfo().Assembly;
            Type messagesResource = nodaTimeAssembly.GetType("NodaTime.Properties.Messages");
            Type patternResource = nodaTimeAssembly.GetType("NodaTime.Properties.PatternResources");
            WindowsRuntimeResourceManager.InjectIntoResxGeneratedApplicationResourcesClass(messagesResource);
            WindowsRuntimeResourceManager.InjectIntoResxGeneratedApplicationResourcesClass(patternResource);
