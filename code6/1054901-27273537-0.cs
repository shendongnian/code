    public  class Student : Staff
    {
        private int matriculationnumber;
        
        public int Matriculationnumber
        {
            get
            {
                return matriculationnumber;
            }
            set
            {
                if (value < 1000 || value > 9000)
                {
                    //ADD VALIDATION 
                }
    
                else
                {
                    matriculationnumber = value;
                }
    
    
            }
        }
    
    }
