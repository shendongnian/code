    string action = "...";
    string message = "...";
    IRequestProcessorFactory factory = new FactoryVersion1();
    IRequestProcessor processor = factory.GetProcessor(action);
    string result = processor.ProcessRequest(message);
