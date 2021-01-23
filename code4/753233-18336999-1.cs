    namespace Site.Models {
        [TableName("Hotel")]
        [PrimaryKey("HotelID")]
        [ExplicitColumns]
        public class Hotel {
            [PetaPoco.Column("HotelID")]
            public int HotelID { get; set; }
    
            [PetaPoco.Column("HotelClaseID")]
            public int? HotelClaseID { get; set; }
    
            [ResultColumn]
            public string HotelClase { get; set; }
    
            [Required]
            [PetaPoco.Column("Nombre")]            
            public String Nombre { get; set; }
    
            ....
