    public class StudentCollection : KeyedCollection<string, Student>
    {
        protected override string GetKeyForItem(Student item)
        {
            return student.Name;
        }
    }
