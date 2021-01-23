    //button can be reused everywhere (including inside your OnShowPopupButtonClick function)
    Button myPopupButton;
    
    public myPopupButton_Loaded(object sender, RoutedEventArgs e) { 
        myPopupButton=sender as Button;
        if ((this.myPopup.IsOpen))
        {
            VisualStateManager.GoToState(myPopupButton, "Pressed", true);
        }
    } 
