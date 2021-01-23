    public class Person {
        public int PersonId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        
        public int NoteData NoteDataId{get;set;}
        
        [ForeignKey("NoteDataId")]
        public virtual NoteData NoteData{get;set;}
    }
    
    public class Product {
        public int ProductId {get;set;}
        public string Name {get;set;}
        
        public int NoteData NoteDataId{get;set;}
        
        [ForeignKey("NoteDataId")]
        public virtual NoteData NoteData{get;set;}
    }
    
    public class NoteData {
        public int NoteDataID {get;set;}
        
        public virtual List<Note> Notes {get;set;}
    }    
    public class Note {
        public int NoteId {get;set;}
        public string Body {get;set;}
        
        public int NoteData NoteDataId{get;set;}
        
        [ForeignKey("NoteDataId")]
        public virtual NoteData NoteData{get;set;}
    }
