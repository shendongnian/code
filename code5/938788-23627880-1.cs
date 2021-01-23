     public string FirstMidName { get; set; }
    [DataType(DataType.Date)]
    [MyAmazingValidationClass(ErrorMessage="You made a big mistake right now!")]
    public DateTime EnrollmentDate { get; set; }
}
