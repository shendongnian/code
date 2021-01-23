     public class NoteBoxViewModel:INotifyPropertyChanged
        {
       //here an example 
            public MusicalNotation MusicalNotation
        { 
        get{
          return _musicalNotation;
          } 
          set{_musicalNotation =Value;
              NotifyPropertyChanged();} }        
        
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
     private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
