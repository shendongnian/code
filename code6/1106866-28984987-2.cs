    public class StudentSpecificCollection
    {
        private string[] arrName;
        private int[] arrAge;
        private object[] arrStudent;
        public MyObject this[int index]
        {
            get
            {
                return new MyObject(this, index);
            }
            set
            {
                if (value.Type.HasFlag(MyObject.MyObjectType.Name))
                {
                    arrName[index] = value;
                }
                if (value.Type.HasFlag(MyObject.MyObjectType.Age))
                {
                    arrAge[index] = value;
                }
                if (value.Type.HasFlag(MyObject.MyObjectType.Student))
                {
                    arrStudent[index] = value;
                }
            }
        }
        public class MyObject
        {
            [Flags]
            public enum MyObjectType
            {
                Name = 1,
                Age = 2,
                Student = 4
            }
            public readonly MyObjectType Type;
            public readonly string Name;
            public readonly int Age;
            public readonly object Student;
            protected MyObject(string name)
            {
                Type = MyObjectType.Name;
                Name = name;
            }
            protected MyObject(int age)
            {
                Type = MyObjectType.Age;
                Age = age;
            }
            protected MyObject(object student)
            {
                Type = MyObjectType.Student;
                Student = student;
            }
            public MyObject(StudentSpecificCollection obj, int ix)
            {
                Name = obj.arrName[ix];
                Age = obj.arrAge[ix];
                Student = obj.arrStudent[ix];
            }
            public static implicit operator string(MyObject obj)
            {
                if (!obj.Type.HasFlag(MyObjectType.Name))
                {
                    throw new Exception();
                }
                return obj.Name;
            }
            public static implicit operator int(MyObject obj)
            {
                if (!obj.Type.HasFlag(MyObjectType.Age))
                {
                    throw new Exception();
                }
                return obj.Age;
            }
            //public static implicit operator object(MyObject obj)
            //{
            //    if (!obj.Type.HasFlag(MyObjectType.Student))
            //    {
            //        throw new Exception();
            //    }
            //    return obj.Student;
            //}
            public static implicit operator MyObject(string name)
            {
                return new MyObject(name);
            }
            public static implicit operator MyObject(int age)
            {
                return new MyObject(age);
            }
            //public static implicit operator MyObject(object student)
            //{
            //    return new MyObject(student);
            //}
        }
    }
