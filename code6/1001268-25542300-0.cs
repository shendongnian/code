    public class Genome
    {
        public List<Chromosome> Chromosomes {get;set;} // has 23 elements on average
    }
    public class Chromosome
    {
        public List<Region> Regions {get;set;}
    }
    public class Region
    {
        public List<BasePair> BasePairs {get;set;}
    }
    public class BasePair
    { 
       // some combinations of proteins
    }
