    // Handle a property Wobbler which identifies an object whose Wibbled event
    // I want to handle with my WibbleWobble method.
    Woozle _wobble;
    Woozle Wobbler {
      get { return _wobbler; }
      set {
        var wasWobbler = _wobbler
        if (wasWobbler == value) return; // Don't unsubcribe and resubscribe same object
        if (wasWobbler != null)
          wasWobbler.Wibbled -= WibbleWobble; // Unsubscribe old event
        if (value != null)
          value.Wibbled += WibbleWobble; // Subscribe new event
        _wobbler = value;
      }
    };
