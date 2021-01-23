     public class Compartment
        {
            private int compartmentID;
            private string address;
            private string weight;
            private string name;
    
            public int CompartmentID
            {
                get { return compartmentID; }
                internal set { compartmentID = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
                
            public string Weight
            {
                get { return weight; }
                set { weight = value; }
            }           
    
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
        }
 
     public class Form1
        {
            private List<Compartment> compartments;
    
            public void Form_Load()
            {
                compartments = new List<Compartment>();
            }
    
            private void AddCompartment(string name, string weight, string address)
            {
                Compartment newCompartment = new Compartment() { CompartmentID = compartments.Count + 1, Address = address, Name = name, Weight = weight };
    
                compartments.Add(newCompartment);
            }
    
            private void UpdateCompartment(int id, string name, string weight, string address)
            {
                //Update based on id
            }
    
            private void RemoveCompartment(int id)
            {
                compartments.Remove(id);
            }
        }
