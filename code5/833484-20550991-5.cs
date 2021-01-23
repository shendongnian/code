    public class PhysicianSpecialtyBridge
    {
       // the pairing object should have the ID
       public virtual int Id { get; set; }
       public virtual Physician  Physician { get; set; }
       public virtual Speciality Speciality{ get; set; }
       ...
    
