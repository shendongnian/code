     public class NoteBoxViewModel:INotifyPropertyChanged
        {
       //here an example 
            public MusicalNotation MusicalNotation
        { 
         get{
             return _musicalNotation;
            } 
          set{ _musicalNotation =Value;
                 // by using [CallerMemberName] you  don't  need to pass the name of the method  
                NotifyPropertyChanged();}
              }        
        
            public NoteBoxViewModel()
            {
                MusicalNotation = new MusicalNotation();
                KeyboardHotkeyCommand = new KeyboardHotkeyCommand(this);
                IsSelected = true;
        
                MusicalNotation.Note = Notes.N1;
                MusicalNotation.Dot = 1;
                MusicalNotation.Octave = -2;
                MusicalNotation.Accidental = Accidentals.Flattened;
               
            }
     public event PropertyChangedEventHandler PropertyChanged;
    
     private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
