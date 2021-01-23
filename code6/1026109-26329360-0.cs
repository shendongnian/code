    System.Reflection.FieldInfo fi = typeof(Page).GetField("_fOnFormRenderCalled", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    if (fi != null)
    {
    	fi.SetValue(this, false);
    }
