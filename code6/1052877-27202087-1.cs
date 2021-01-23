    Public FormB RegistrationForm {get; set;}
    private void Form_Load(object sender, EventArgs e)
    {
       // If FormB is open then get its instance
       this.RegistrationForm = Application.OpenForms.Cast<Form>().OfType<FormB>().FirstOrDefault ();
       if(this.RegistrationForm != null)
       {
           RegistrationForm.NewUserRegistered += ANewUserHasBeenRegistered;
           RegistrationForm.Closed += FormBHasBeenClosed;
       }
       // Now load the current user list in your grid view.
       LoadUserList(); // this contains the code that initializes the gridView
    }    
    // this is the subscription method that will be called by the FormB instance
    // every time a new user registers
    private void ANewUserHasBeenRegistered(string userName)
    {
        // Here you have two options.
        // Reload the grid I.E. call LoadUserList();
        // Try to manually add the new user at the current gridview.
        .....
    }
    // this will be called by the framework when FormB instance closes. 
    // It is important to avoid any possibility to reference a destroyed form 
    // using the RegistrationForm variable.
    private void FormBHasBeenClosed(object sender, FormClosedEventArgs e) 
    {
        this.RegistrationForm = null;
    }
