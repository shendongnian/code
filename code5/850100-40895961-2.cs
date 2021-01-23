    private void GetPossibleForeignKeyValues(string tableName, string propertyName,
        ref object originalFKValue, ref object newFKValue,
        List<AssociationType> FKList, IObjectContextAdapter contextAdapter)
    {
        // If this property is part of a foreign key, look up and set the FKValue to the text
        // value of the foreign key. Otherwise, just leave the FKValue alone.
        // Look into the FK attributes and find that the "To Role" is out current table,
        // and the "To Property" is out current property.
        AssociationType thisFk = FKList.FirstOrDefault(x =>
            tableName.Contains(x.ReferentialConstraints[0].ToRole.Name)
            && propertyName.Contains(x.ReferentialConstraints[0].ToProperties[0].Name));
        // If fkname has no results, this is not a foreign key and we are done.
        if (thisFk != null)
        {
            // Now that we know the foriegn key, look up the Name value in the other table.
            string lookUpTableName = thisFk.ReferentialConstraints[0].FromRole.Name;
            string lookUpPropertyName = thisFk.ReferentialConstraints[0].FromProperties[0].Name;
            //Assuming the FK column name is "Name".
            //Use the idea in @JamesR's solution or some sort of LookUp table if it is not.
            string commandText = BuildCommandText("Name", lookUpTableName, lookUpPropertyName);
            originalFKValue = contextAdapter.ObjectContext
                .ExecuteStoreQuery<string>(commandText, new SqlParameter("FKID", originalFKValue))
                .FirstOrDefault() ?? originalFKValue;
            newFKValue = contextAdapter.ObjectContext
                .ExecuteStoreQuery<string>(commandText, new SqlParameter("FKID", newFKValue))
                .FirstOrDefault() ?? originalFKValue;
            
        }
    }
