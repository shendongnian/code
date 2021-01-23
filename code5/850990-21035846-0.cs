    public class Skill {
        //....variables
    }    
    
    public List<Skill> allSkills    = new List<Skill>();
    public Skill[] skillArray;
        
    void GetArray ()
    {
       string blah = PlayerPrefs.GetString("CatSkills");
       JsonConvert.DeserializeObject<List<Skill>>(blah).CopyTo(skillArray, 0);
    }
