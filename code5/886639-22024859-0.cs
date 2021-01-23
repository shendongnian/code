    >  private Contact _selectedContact;
    > 
    > 
    > 
    > public Contact SelectedContact
    >         {
    >             get
    >             {
    >                 return this._selectedContact;
    >             }
    >     
    >             set
    >             {
    >                 if (value != this._selectedContact)
    >                 {
    >                     this._selectedContact= value;
    >                     NotifyPropertyChanged();
    >                 }
    >             }
    >         }
