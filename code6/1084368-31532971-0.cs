        Delta<User> filteredDelta = new Delta<User>();
        if (originalDelta.GetChangedPropertyNames().Contains("FirstName"))
        {
            filteredDelta.TrySetPropertyValue("FirstName", originalDelta.GetEntity().FirstName);
        }
        if (originalDelta.GetChangedPropertyNames().Contains("LastName"))
        {
            filteredDelta.TrySetPropertyValue("LastName", originalDelta.GetEntity().LastName);
        }    
        filteredDelta.Patch(selectedUser);
