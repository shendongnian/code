    public void InitializeCommands(){
        AddEContactCommand = new ICommandImpl(AddElement); //you'll have to derive an implementation for ICommand for this
    }
    public ICommand AddContactCommand
    {
        get { return _addContactCommand; }
        set { SetValue(ref _addContactCommand, value); } //setvalue is wrapper for notifychanged from viewmodelbase abstract class
    }
    public void AddContact() {
         //do add contact
         //set properties null
    }
