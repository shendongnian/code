    public class CarFieldsDTO
    {        
        public int ID { get; set; }
        
        public string CarNumber { get; set; }
        
        public DateTime? ArriveDate { get; set; }
		
        public IEnumerable<CarFieldsDTO> Fields { get; set; }
    }
	
	
