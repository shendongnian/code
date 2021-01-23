    private List<string> _subjectTaught;
    public ReadOnlyCollection<string> SubjectTaught
    { 
       get{ _subjectTaught.AsReadOnly();}
    }
