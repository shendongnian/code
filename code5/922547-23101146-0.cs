     private MvxCommand terminate;
       public System.Windows.Input.ICommand Terminate_Something
       {
           get
           {
               terminate = terminate ?? new MvxCommand(MethodSomething);
               return terminate;
           }
       }
