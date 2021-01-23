    class PermissionsKey
    {
        public string sectionName;
        public string KeyIndex;
    
        public override Equals(object obj)
        {
            var key = obj as PermissionsKey;
            if (key == null)
                return false;
            // here you need to define something that indicates your object is the same as another 
            //  instance of PermissionsKey
        }
        public override GetHashcode()
        {
            //Implement a method to return an appropriate hashcode for the object.
        }
    }
