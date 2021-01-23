     private void ToggleButton_OnUnchecked(Object sender, RoutedEventArgs eventArgs)
     {
          AllOrdersView.Filter = element => AllCarrierTypes
                  .Where(x => x.Active).Contains(((Order)element).CarrierType); 
     }
   
