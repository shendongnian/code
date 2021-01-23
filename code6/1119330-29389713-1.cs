    Coordinator.Messages.AddRange
    (
        new List<Message> 
        {
             new Message 
             { 
                 Operation = Operation.DataInitialization, 
                 Task = dataInitTask
             },
             ..., // <--- more messages
        }
    );
