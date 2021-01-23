    protected virtual CommandProcessingResult RecogniseAndProccessCommand<T>
        (T command) where T : Command
    {
        var commandProcessor = (CommandProcessor)ServiceLocator.GetInstance<ICommandProcessorGeneric>(typeof(T).Name);
        return commandProcessor.ProcessCommand(command);
    }
   
