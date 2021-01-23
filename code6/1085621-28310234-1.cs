    // Assuming this property is present in IView<User>
    public User CurrentSelectedUser { get; set; }
    public void EditUser()
    {    
        this.editService.EditEntity(this.CurrentSelectedUser);
    }
