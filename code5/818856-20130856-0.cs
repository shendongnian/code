     public MvxCommand NextCommand {
        get {
             // this return is executed when the binding happens
             return new MvxCommand(() => {
                 // this switch is executed when the Click happens
                 switch(nextViewId) {
                    case 0:
                      // ...
                    case 1:
                      // ...
               }
             });
        }
    }
