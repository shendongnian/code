     private void AddItem(IList list, Type type, string valueMember,string displayMember, string displayText)
        {
            //Creates an instance of the specified type 
            //using the constructor that best matches the specified parameters.
            Object obj = Activator.CreateInstance(type);
            // Gets the Display Property Information
            PropertyInfo displayProperty = type.GetProperty(displayMember);
            // Sets the required text into the display property
            displayProperty.SetValue(obj, displayText, null);
            // Gets the Value Property Information
            PropertyInfo valueProperty = type.GetProperty(valueMember);
            // Sets the required value into the value property
            valueProperty.SetValue(obj, -1, null);
            // Insert the new object on the list
            list.Insert(0, obj);
        }
