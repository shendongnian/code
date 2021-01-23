    private bool IsValid()
        {
            if (this[nameof(Property1)] != null ||
                this[nameof(Property2)] != null ||
                this[nameof(Property3)] != null ||
                .....
                this[nameof(PropertyX)] != null)
            {
                return false;
            }
            return true;
        }
