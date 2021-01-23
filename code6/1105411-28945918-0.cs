    public class Discipline
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public virtual ICollection<DisciplineRequirement> Requirements {get;set;}
        public virtual ICollection<DisciplineRequirement> RequiredBy {get;set;}
    }
    public class DisciplineRequirement
    {
        public int DisciplineId {get;set;}
        public int RequiredDisciplineId {get;set;}
        public virtual Discipline Discipline {get;set;}
        public virtual Discipline RequiredDiscipline {get;set;}
    }
