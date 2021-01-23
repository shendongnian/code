    Entitie Lottery        
    public Lottery( )    
    {       
      FuncionariosSorteados = new List <Worker>();   
      }     
    public Int32 Id { get; set; }       
    [Display(Name = "Tipo")]     
    public    String Tipo { get; set; }     
    [Display(Name = "Data")]    
    public DateTime Data { get; set; }      
     [Display(Name = "Observações")]      
     public virtual List<Worker> FuncionariosSorteados { get; set; }
