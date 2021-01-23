    bool p1 = true; // can be others values
    bool p2 = false; // can be others values
    object[] args = new object[2] { p1, p2 };
    var retval = obj.Invoke("PrivateMethod", args);
    
    p1 = (bool)args[0];
    p2 = (bool)args[1];
