    class Student
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int StudentID { get; set; }
            public DateTime Dob { get; set; }
    
            [ForeignKey("Person")]
            [Key]
            public int PersonID { get; set; }
            public int Student_TypeID { get; set; }
    
            //navigation properties
            public virtual Person Person { get; set; }
        }
    
    class Person
        {
            [Key]
            public int PersonID { get; set; }
            public string Phone_Number { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
    
            //navigation properties
            public virtual Student Student { get; set; }
    
            public override string ToString()
            {
                return Last_Name + ", " + First_Name;
            }
        }
