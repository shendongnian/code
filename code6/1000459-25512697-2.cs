    {
        XDictionary<string, object> xDict = new XDictionary<string,object>();
        xDict["Test"] = 5; // This will call the set { } code above.
        // Be wary though, if you try to do this through another type like this:
        // It will not call your setter code, but but the base implementation
        ((IDictionary<string, object>)xDict)["Test2"] = 6;
    }
