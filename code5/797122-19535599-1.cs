        class Student
        {
            //ideally properties
            public int id
            public string name;
            public int age;
            public int marks;
    
            private int friendId; //private it is
    
            public Student GetFriend()
            {
                return db.GetStudent(friendId);
            }
        }
