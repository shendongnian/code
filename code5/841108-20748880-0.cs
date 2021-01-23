    internal bool SupressSelectIndexChanged {get; set;}
    private void SomeCallingMethod(){
       this.SupressSelectIndexChanged = true;
       combobox.SelectedIndex = 0;
       this.SupressSelectionIndexChanged = false;
    }
    
    private void combobox_SelectIndexChanged(object sender, EventArgs e){
        if(this.SupressSelectIndexChanged){ return; }
    
        // - execution logic
    }
