Installer classe's Install()
    public override void Install(System.Collections.IDictionary stateSaver)
            {
                base.Install(stateSaver);
    
                Form1 validationForm = new Form1();
                validationForm.ShowDialog();
    
                if (!validationForm.IsValidPassword)
                {
                    throw new Exception("Invalid Password. Please enter valid password to continue installation");
                }
            }
