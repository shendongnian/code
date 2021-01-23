    public ICommand MouseUpCommand
    {
        get 
        {
            if (this.mouseUpCommand == null)
            {
                this.mouseUpCommand = new RelayCommand(this.OnMouseUp);
            }
            
            return this.mouseUpCommand;
        }
    }
    
    private void OnMouseUp()
    {
        // Handle MouseUp event.
    }
