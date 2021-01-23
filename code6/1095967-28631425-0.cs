    private Boolean isClicked = false;
    private void Toggle_Click (object sender, RoutedEventArgs e){
        if (isClicked) {
         FocusManager.SetFocusedElement(this, Toggle);
        }
        else {
           FocusManager.SetFocusedElement(this, null);
        }
        isCLicked = !isCLicked;
    }
