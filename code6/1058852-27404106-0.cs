    public class Mother : ObservableObject
    {
        // ...
        public Child GiveBirth()
        {
            var newBorn = new Child(this);
            this.Children.Add(newBorn);
            return newBorn;
        }
        // ...
    }
