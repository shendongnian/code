    public class Book
    {
       //To create a constructor, you just create a method using the class name. 
       public Book(string title, string author)
       {
          this.Title = title;
          this.Author = author; 
       }
       //Creating a constructor with parameters eliminates the default 
       //constructor that's why you might want to add this if you want to          
       //instantiate the class without a parameters. 
       public Book() { } 
       public string Title {get;set;}
       public string Author {get;set;}
    }
