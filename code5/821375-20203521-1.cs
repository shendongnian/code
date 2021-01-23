    class SomePrettyImportantStuff {
        [Key]
        public int ID { get; set; }
        public int OtherId1 { get; set; }
        public int OtherId2 { get; set; }
        [ForeignKey("OtherId1")]
        public virtual OtherImportantStuff Nav1 { get; set; }
        [ForeignKey("OtherId2")]
        public virtual OtherImportantStuff Nav2 { get; set; }
    }
    class OtherImportantStuff {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<SomePrettyImportantStuff> SoldStuff { get; set; }
        public virtual ICollection<SomePrettyImportantStuff> BoughtStuff { get; set; }
    }
