    private List<ParentClass> AssignValue<T>(List<ParentClass> lstParent)
        {
            foreach (var item in lstParent)
            {
                dynamic objData = Convert.ChangeType(item, typeof(T));
                if (objData != null)
                {
                    //This call would throw exception if CommonProperty is not member of the T Class
                    objData.CommonProperty = 5;
                }
            }
            return lstParent;
        }
    
