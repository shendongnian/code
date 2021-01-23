    public partial class Human
    {
       public Human()
       {
          Pets = new List<Pet>();
       }
       public int HumanID { get; set; }
       public string Name{ get; set; }
       public virtual ICollection<Pet> Pets { get; set; }
    }
    
    public partial class Pet
    {
       public Pet()
       {
          Owners= new List<Human>();
       }
       public int PetID { get; set; }
       public string Name{ get; set; }
       public virtual ICollection<Human> Owners { get; set; }
    }
