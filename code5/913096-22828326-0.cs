    public class Profile
    {
    public string Datakey{get; set;}
    public ProfileData Data{get; set;}
    }
    
    public class ProfileData 
    {
    public string Name{get;set;}
    //define all your profile properties
    ...
    ...
    
    }
    
    //Now in code
    
    
    IsolatedStorageSettings ProfileSettings = IsolatedStorageSettings.ApplicationSettings;
    
    List<Profile> ProfileList = new List<Profile>();
    
    //Add data in ProfileList instead of IsolatedStorageSettings 
    
    Profile profileData = new Profile();
    ProfileData data = new ProfileData ();
    //Add properties
    data.Name ="PlayerOne";
    .....
    ...
    profileData.Datakey="PlayerOneKey";
    profileData.Data = data;
    ProfileList.Add(profileData);
    
    ProfileSettings.Add("AllProfile",ProfileList);
    ProfileSettings.Save();
