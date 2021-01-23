    Type ITextTemplatingEngineHost.ResolveDirectiveProcessor(string processorName)
        {
            if (string.Compare(processorName, "T4VSHost", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return typeof(FallbackT4VSHostProcessor);
            }
            throw new Exception("Directive Processor not found");
        }
