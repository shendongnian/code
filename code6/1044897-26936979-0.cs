    var todos1 = todos2.Except(todos3, new ToDoComparer());
    public class ToDoComparer : IEqualityComparer<ToDo>
    {
        public bool Equals(ToDo x, ToDo y)
        {
            //Check whether the compared objects reference the same data. 
            if (ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null. 
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
    
            return x.Name.Equals(y.Name);
        }
    
        public int GetHashCode(ToDo todo)
        {
            return ReferenceEquals(todo, null) ? 0 : todo.Name.GetHashCode();
        }
    }
