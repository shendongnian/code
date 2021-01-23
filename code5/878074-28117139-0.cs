       public override ControlResult Result
            {
                get
                {
                    return new ControlResult(this.ControlName,
                                         (this.buttonList.SelectedItem != null 
                                            && this.buttonList.SelectedIndex == this.buttonList.Items.Count - 1
                                            && !string.IsNullOrEmpty(this.InputText.Text)) ?
                                         this.buttonList.SelectedItem.Text + ", " + this.InputText.Text :
                                         (this.buttonList.SelectedItem != null? this.buttonList.SelectedItem.Text  : string.Empty),
                                          this.buttonList.SelectedValue ?? string.Empty);
    
                }
            }
