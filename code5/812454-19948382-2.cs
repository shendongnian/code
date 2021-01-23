    public int? GradeValue {get;set;}
    [NotMapped]
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade 
    { 
        get 
        { 
             return GradeValue.HasValue ? (Grade?) GradeValue.Value : null; 
        } 
    }
