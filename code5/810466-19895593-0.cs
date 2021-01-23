    class School
    {
        public string student;
        public object[] data;
    }
    School datum = JsonConvert.Deserialize<School>(jsonStr);
    //Do stuff with datum...
