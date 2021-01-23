    public AxisObject getAxisObjectByName(string name)
        {
            FieldInfo[] Comboproperties = typeof(DrivesObject).GetFields();
            foreach (var property in Comboproperties)
            {
                if (property.Name == name)
                {
                    return (AxisObject)property.GetValue(PersistantVariables.Instance.Drives);//pass the instance you're wanting to return child object instance from
                }
            }
            return null;
        }
