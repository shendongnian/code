    public class Physician
    {
        ...
        public virtual List<Specialty> Specialties{ get; set; }
    public class Specialty
    {
        ...
        public virtual List<Physician> Physicians{ get; set; }
