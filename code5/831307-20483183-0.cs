    private _spinnerClass = string.empty;
    public string SpinnerClass 
    {
       get { return _spinnerClass; }
       set { _spinnerClass = value; }
    }
    protected void Page_Render(o,e)
    {
       Spinner.Attributes.Add('class', _spinnerClass);
    }
