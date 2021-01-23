    public DateTime BirthDate { get; set; }
            public int Age
            {
                get
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - BirthDate.Year;
                    if (BirthDate > today.AddYears(-age)) age--;
                    return (int)age;
                }
    
            }
