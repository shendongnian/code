    private bool IsValid()
        {
            if (string.IsNullOrEmpty(this[nameof(Property1)]) &&
                string.IsNullOrEmpty(this[nameof(Property2)]) &&
                string.IsNullOrEmpty(this[nameof(Property3)]) &&
                .....
                string.IsNullOrEmpty(this[nameof(PropertyX)]))
            {
                return true;
            }
            return false;
        }
    
