    public class Job
    {
       public string name;
       public string id;
       public string phone;
       public string email;
       public string[] experience;
    }
    Job j = JsonConvert.DeserializeObject<Job>(jsonString);
    string output = JsonConvert.SerializeObject(j);
    //will include "optional" parameters, meaning if there is no phone value it will be an empty string but the property name will still be there.
