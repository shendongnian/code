    class Program
    {
        public static void Main(string[] args)
        {
            List<string> Profiles = new List<string>();
            List<int> state = new List<int>();
            // Just filling the entities as per your needs
            for (int i = 0; i < 5; i++)
            {
                Profiles.Add("P-" + i.ToString());
                state.Add(i);
            }
            listOfProfileState ProfileStateColl = new listOfProfileState();
            for (int i = 0; i < Profiles.Count; i++)
            {
                ProfileStateColl.Add(new ProfileState() { Profile = Profiles[i], State = state[i] });
            }
        }
    }
    public class ProfileState
    {
        public string Profile { get; set; }
        public int State { get; set; }
    }
    public class listOfProfileState : List<ProfileState>
    {
    }
