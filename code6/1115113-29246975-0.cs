    class Profile{
      private Dictionary<string,string> _profileDetails;
      public Dictionary<string,string> ProfileDetails { get { return _profileDetails; } }
      public Profile() { _profileDetails = new Dictionary<string,string>(); }
    }
