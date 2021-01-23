    public class SchoolClass : KeyedCollection<uint, Student>
        {
            protected override uint GetKeyForItem(Student newStudent)
            {
                return newStudent.Number;
            }
        }
