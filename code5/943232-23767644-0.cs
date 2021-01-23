    class Message {
        public string Title {get;set;}
        public string Description {get;set;}
        public int GetHashCode() {return 31*Title.GetHashCode()+Description.GetHashCode();}
        public bool Equals(object other) {
            if (other == this) return true;
            Message obj = other as Message;
            if (obj == null) return false;
            return Title.Equals(obj.Title) && Description.Equals(obj.Description);
        }
    }
    ISet<Message> hash = new HashSet<Message>();
