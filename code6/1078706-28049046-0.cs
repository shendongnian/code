    internal abstract partial class EventSymbol : Symbol, IEventSymbol
    {
        ...
        IMethodSymbol IEventSymbol.RaiseMethod
        {
            get
            {
                // C# doesn't have raise methods for events.
                return null;
            }
        }
        ...
    }
