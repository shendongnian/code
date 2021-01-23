    new DeadlockRetryCommandHandlerDecorator<MessageCommand>(
        new TransactionCommandHandlerDecorator<MessageCommand>(
            new MessageLogger(
                new MessageSender(),
                new DeadlockRetryCommandHandlerDecorator<MessageLogger>(
                    new TransactionCommandHandlerDecorator<MessageLogger>(
                        new Logger()
                    )
                )
            )
        )
    )
