    // in child project
    class ValueUser
    {
        public int GetValue()
        {
            ChildValues cv = new ChildValues();
            return cv.Key2;
        }
    }
