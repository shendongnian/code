    public class Person
    {
        private string name;
        string Name { 
        get{return name;} 
        set
        {
            //Validation Logic
            if(name.Trim() == ""){throw new Exception("Invalid value for Name.");}
            //If all validation logic is ok then
            name = value;
        }
        }
    }
