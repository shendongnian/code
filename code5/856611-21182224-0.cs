    foreach (User employee in Users)
    {
        XElement myNode;
        if (dictionary.TryGetValue(employee.ID, out myNode))
        {
            // Use myNode
        }
        else
        {
            // Employee not found
        }
    }
