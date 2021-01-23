    enum Status { Disabled = 0, Enabled = 1 }
    Status a = Status.Disabled;
    Status b = Status.Enabled;
    if( (a | b) == Status.Enabled){
         //Code
    }
