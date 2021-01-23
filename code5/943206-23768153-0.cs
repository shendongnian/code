    public YourViewModel {
       public IEnumerable<YourBaseControlViewModel> Controls {get; set;}
       public YourViewModel()
       {
           Controls = new List<YourBaseControlViewModel();
           Controls.Add(new YourFunnyControlViewModel());
       }
    
       // Called from View by Command.
       public void DuplicateControl(YourBaseControlViewModel Control)
       {
    
          // either duplicate it using cloning, or add the same reference.
          Controls.Add(Control);
    
       }
    }
