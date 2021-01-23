    public class Physician
    {
        ...
        public virtual List<PhysicianSpecialtyBridge> Specialties{ get; set; }
    public class Specialty
    {
        ...
        public virtual List<PhysicianSpecialtyBridge> Physicians{ get; set; }
