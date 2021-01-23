    // Domain object
    public class MyDomainObject {
        public string Name { get; internal set; }
        public string Info { get; internal set; }
    }
    // DTO
    public class MyDomainObjectDto {
        public Name { get; internal set; } // <-- The problem is in setter access modifier (and carelessly performed refactoring).
        public string Info { get; internal set; }
    }
