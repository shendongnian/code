    public class AgeCalculator
    {
        public void SetAge ( Client client )
        {
            client.Age = GetAge( client.Id );
        }
        private Func<int,int> _getAge;
        public Func<int,int> GetAge 
        {
                private get
                {
                    if(_getAge == null)
                        _getAge = getAge;
                    return _getAge;
                }
                set
                {
                    if(value == null)
                        _getAge = getAge;
                    else
                        _getAge = value;
                }
        }
        private int getAge ( int clientId )
        {
            return 10;
        }
    }
   
    //assume we are in main
    var cl = new Agecalculator();
    var client = new Client(1,"theOne");
    var client2 = new Client(2,"#2");
        
    cl.SetAge(client); //set 10
    cl.GetAge = getAge;
    cl.SetAge(client); //set 5
    cl.SetAge(client2); //set 5
