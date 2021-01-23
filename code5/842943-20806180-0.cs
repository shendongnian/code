    // DTO
    public class InformationClass{
      public int idInfromation{ get; set; }
      public string Information{ get; set; }
    }
     
    [HttpPost]
     public bool information(InformationDTO Info)
        {
           .....
           return true;
        }
