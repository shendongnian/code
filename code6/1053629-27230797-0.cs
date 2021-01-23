    class MyViewModel
    {
         [MinLength(6)]
         [HasUpper(1)]
         [HasLower(1)]
         // [Required] remove this line
         public String Password { get; set; }
    }
