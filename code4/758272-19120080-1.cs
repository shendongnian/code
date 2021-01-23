    class BindingMap<BusinessClass> {
      // ....
        public void AddBind(Expression<Func<BusinessClass, double>> variable, string columnName) {
            // Add binding for double
        }
        public void AddBind(Expression<Func<BusinessClass, DateTime>> variable, string columnName) {
            // Add binding for DateTime
        }
        // ... 
    };
