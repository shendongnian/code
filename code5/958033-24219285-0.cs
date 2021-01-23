    public DateTime Date { get; set; }
    
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public DateTime PersianDate
    	{
    	    get
    		{
    				var value  = ConvertToHijri(Date);
    
    				return (value);
    		}
    	}
