    public class Prm_Staff_View_Model
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool Active { get; set; }
        //The selected One
        public int SelectedSalutationID { get; set; }
        //The list with the salutations availables
        public List<Prm_Salutation> AvailableSalutations{get;set;} 
        public Prm_Staff() { }        
    }
