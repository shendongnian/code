    private void ValidateEditViewModel(ViewModel model){
        if(model.. // something is wrong)
        {
            // this sets ModelState.IsValid = false
            ModelState.AddModelError("<,PropertyNameThatIsInError>>", "The item is removed from your cart");  
        }
    }
