    public class OpenDays
    {
       public override ToString()
       {
           StringBuilding formattedOpenDays = new StringBuilder();
           
           //od is an object of type of single element in OpenDays collection
           foreach(OpenDay od in OpenDays)
           {
               formattedOpenDays.Add(od.ToString());
           }
           return formattedOpenDays.ToString();
       }   
    }
