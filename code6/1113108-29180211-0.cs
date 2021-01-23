    public MyClass MyObj {
        get {
            if (ViewState["MyObj"] == null){
                 ViewState["MyObj"] = new MyClass();
            }
            return ViewState["MyObj"]; 
        }
        set {
            ViewState["MyObj"] = value;
        }
    }
