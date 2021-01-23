    int hashCode = this.GetType()
                       .GetProperties()                // Get property names.
                       .Select(o => o.GetValue(this))  // Look up all property values.
                       .GetHashCode();                 // Combine all into hashcode.
    hashCode = hashCode + this.GetHashCode();          // Make unique for each class instance.
