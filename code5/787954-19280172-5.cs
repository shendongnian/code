    public class Note {
        public int NoteId {get;set;}
        public string Body {get;set;}
        public virtual User Author {get;set;}
        
    	public int? PersonId { get; set; }
    	public virtual Person Person { get; set; }
    	
    	public int? ProductId { get; set; }
    	public virtual Product Product { get; set; }
    }
