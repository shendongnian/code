    private string _notetext;
    public string NoteText
    {
          get
          {
             return  _notetext;
          }
          set
          {
              if(_notetext!=value)
              {
                 _notetext=value;
                 Notify("NoteText");
              }
          }
    }
