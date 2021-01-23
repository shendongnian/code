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
    
            [PetaPoco.Column("Nombre")]
            [Required(]
            public String Nombre { get; set; }
    
            ....
