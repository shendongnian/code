    public static void JobFunction(
        [ServiceBusTrigger("inputqueue", AccessRights.Listen)] string message,
        [ServiceBus("outputqueue", AccessRights.Send)] out string message)
    {
        . . .
    }
