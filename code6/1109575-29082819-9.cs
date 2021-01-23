    <type> propObj;
    try
    {
        propObj = obj.Property;
        <type> propArrayObj;
        try
        {
            propArrayObj = propObj[0];
            <type> propArrayObjReturn;
            try
            {
                propArrayObjReturn = propArrayObj.MethodThatReturnsAnotherObject();
            }
            finally
            {
                if (propArrayObjReturn != null) Marshal.ReleaseComObject(propArrayObjReturn);
            }
        }
        finally
        {
            if (propArrayObj != null) Marshal.ReleaseComObject(propArrayObj);
        }
    }
    finally
    {
        if (propObj != null) Marshal.ReleaseComObject(propObj);
    }
