    delegate void ButtonClick();
    
    void OnButtonClick()
    {
        MessageBox.Show("Hello World!");
    }
    
    void Foo
    {
        ButtonClick ButtonClicked = new ButtonClick(OnButtonClick);
        ButtonClicked(); // Execute the function.
    }  
  
   
