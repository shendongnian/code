    public interface IDestinationProvider
    {
        sting Destination { get; }
    }
    string GetDestination(Role role)
    {
        var provider = role as IDestinationProvider;
        if (provider != null)
            return provider.Destination;
        return "Default";
    }
