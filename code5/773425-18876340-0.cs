    public partial class carga
    {
    public int Id{get; set;}
    ..
    ..
    public List<lote> lots{get;set;} 
    }
    
    public partial class lote
    {
    public int Id{get; set;}
    ..
    ..
    public List<reg> regs{get;set;} 
    }
    
    public partial class reg
    {
    public int Id{get; set;}
    ..
    ..
    
    }
