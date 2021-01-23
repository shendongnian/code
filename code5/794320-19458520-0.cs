    class HappyBirthday
    {
        public string Message
        {
            get
            {
                string theMessage;
            
                theMessage = "Happy Birthday " + GivenName + "\n";
                theMessage += "Number of presents = ";
                theMessage += PresentCount.ToString() + "\n";
            
                if (HasParty)
                {
                    theMessage += "Hope you enjoy the party!";
                }
                else
                {
                    theMessage += "No party = sorry!";
                }
            
                return theMessage;
            }
        }
        
        public string GivenName { private get; set; }
        
        public int PresentCount { private get; set; }
        
        public bool HasParty { private get; set; }
    }
