    [DisplayName("Departure Dates")]
     public DateTime? DepartureFrom { get; set; }
    
     [DisplayName("Departure Dates")]
     [IsDateAfter("DepartureFrom", true, ErrorMessage = "* Departure To Date must be after Departure From Date")]
     public DateTime? DepartureTo { get; set; }
