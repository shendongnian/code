    public class DbUserChoice 
    { 
        public int Id { get; set; } 
        public string Description { get; set; } 
        public virtual void Parse(XElement node)
        {
            //assign properties from XElement here
            //override this method in DbUserBodyType to add additional logic
        } 
    } 
