    // In the controller...
    var validatorType = typeof(ICommandValidator<>)
                          .MakeGenericType(message.GetType());
    var handler = this.Request
                      .GetDependencyScope()
                      .GetService(validatorType);
