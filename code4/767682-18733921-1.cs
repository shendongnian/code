    public class Movie
    {
    public int ID { get; set; }
    [Required]
    public string Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public string Genre { get; set; }
    [DataType(DataType.Currency), Range(1,100)]
    public decimal Price { get; set; }
    [StringLength(5)]
    public string Rating { get; set; }
    [StringLength(200)]
    public string comments { get; set; }
    //change here
    public int DirectorID {get; set;}
    public Director director { get; set; }
    }
