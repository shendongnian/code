    private bool IsValid()
        {
            if (this[nameof(Property1Name)] != null ||
                this[nameof(Property2Name)] != null ||
                this[nameof(Property3Name)] != null ||
                .....
                this[nameof(Quantity)] != null)
            {
                return false;
            }
            return true;
        }
