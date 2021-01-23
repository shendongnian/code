      class Utility
      {     
        private int _activeUserID;
        private string _activeUserName;     
        public int ActiveUserID
        {
          get { return _activeUserID;}
          set { _activeUserID = value; }
        }
        public string ActiveUserName
        {
          get { return _activeUserName; }
          set { _activeUserName = value; }
        }
  
        // You don't need this method, you can store id and username like this:
        // tool1.ActiveUserID = currentUserID;
        // tool1.ActiveUserName = currentUserName;
        public void StoreActiveUser(int currentUserID, string currentUserName)
        {    
          ActiveUserID = currentUserID;
          ActiveUserName = currentUserName;
        }
        // no need for this method either, you can use this:
        // int id = tool1.ActiveUserID;
        public int GetActiveUser()
        {
          return ActiveUserID;
        }
      }
