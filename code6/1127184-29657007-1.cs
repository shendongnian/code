          public PositionAttributesViewModel()
          {
            PositionAttributeMasterCollection = new    
                    ObservableCollection<PositionAttributes >();
 
            SelectionChangedCmd = new RelayCommand(() =>        
                  PositionAttributesSelectionChanged(), () => true);
         }
       
      
     //implement what you want to do on selection 
      private void PositionAttributesSelectionChanged()
      {
          if(PositionAttributeMasterCollection !=null &&     
           SelectedAttributedMaster !=null)
            {
               PositionAttributes feature = SelectedAttributedMaster  as     
               PositionAttributes 
               //Update the window whenever we select a new feature.
               Dispatcher.CurrentDispatcher.DynamicInvoke(delegate()
               {
                    //further implementation
                             
               });
            }
      }
