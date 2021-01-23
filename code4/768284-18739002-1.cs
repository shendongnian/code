    public static SelectList SelectListFor<T>() 
			where T : struct
    {
        var t = typeof (T);
        
        if(!t.IsEnum)
        {
            return null;
        }
        var values = Enum.GetValues(typeof(T)).Cast<T>()
                       .Select(e => new { Id = Convert.ToInt32(e), Name = e.GetDescription() });
        return new SelectList(values, "Id", "Name");
    }
