    [XmlRoot("PIChart")]
    public class PieChart
    {
        [XmlElement("NumberofSectors")]     public int         NumberOfSectors     { get ; set ; }
        [XmlElement("AngleofSector")]       public SectorAngle AngleOfSector       { get ; set ; }
        [XmlElement("ColorofSectorRegion")] public SectorColor ColorOfSectorRegion { get ; set ; }
    }
    public class SectorAngle
    {
        [XmlElement] public int[] StartAngle { get ; set ; }
        [XmlElement] public int[] EndAngle   { get ; set ; }
    }
    public class SectorColor
    {
        [XmlElement] public int    Region { get ; set ; }
        [XmlElement] public string Color  { get ; set ; }
    }
