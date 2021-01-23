    //is a Student an Item? I think not
    class Student 
    {
       public string date;
       public string returnDate;
    
       public Student(string newDate, string newReturnDate)
       {
           date = newDate;
           returnDate = newReturnDate;
       }
       public void borrowMovie(Movie objMovie)
       {
           objMovie.borrowCopy(this);
       }
       public void borrowCD(CD objCD)
       {
           objCD.borrowCopy(this);
       }
    }
