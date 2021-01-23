    public static T MapDTO<T>(object dto) where T : new()
    {
        T Result = new T();
    
        if (dto == null)
            return Result;
    
        dto.GetType().GetProperties().ToList().ForEach(p =>
            {
                PropertyInfo prop = Result.GetType().GetProperty(p.Name);
                
                if (prop != null && prop.CanWrite)
                {
                    try
                    {
                        var convertedVal = Convert.ChangeType(p.GetValue(dto, null), prop.PropertyType);
                        prop.SetValue(Result, convertedVal, null);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            prop.SetValue(Result, p.GetValue(dto, null), null);
                        }
                        catch (Exception ex1) { }
                    }
                }
            });
        return Result;
    }
