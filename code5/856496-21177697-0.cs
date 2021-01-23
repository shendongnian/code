    public class Block
    {    
       public string Name { get; set; }
       public List<BlockAttribute> Attributes { get; set; }
    } 
    public class BlockAttribute 
    {  
       public string Tag { get; set; }
       public string Layer { get; set; }
    }
