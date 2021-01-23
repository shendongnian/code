    private string _text;
    
    /// <summary>
    /// Gets the Text
    /// </summary>
    /// <remarks>May be set within this class or derived classes</remarks>
    public string Text {
        get { return _text; }
        protected set {
            _text = value;
        }
    }
