    // New delegate for each call
    Increment()(); // Prints 1
    Increment()(); // Prints 1 again
    Increment()(); // Prints 1 again
    // Same delegate three times
    var action = Increment();
    action(); // Prints 1
    action(); // Prints 2
    action(); // Prints 3
