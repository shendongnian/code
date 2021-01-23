    public class NotesMap: ClassMap<Notes>{
        public NotesMap(){
            Id(x => x.Id);
            Map(x => x.Head);
            Map(x => x.Text);
    
            References(x => x.Owner)
                .Cascade.SaveUpdate();
    
            Table("Notes");
        }        
    }
