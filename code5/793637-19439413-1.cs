    using System.Reflection;
    private PictureBox DoSomethingWithProperties(PictureBox picturebox)
    {
        Type pictureboxType = picturebox.GetType();
        PictureBox instance = (PictureBox)Activator.CreateInstance(pictureboxType)
        // The above code is only used to create an instance of the picturebox type. 
        // This will enable modification/changes to the picturebox property values during runtime via late-binding.
        PropertyInfo DefaultSize= instance.GetType().GetProperty("DefaultSize", BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo ClientSize= instance.GetType().GetProperty("ClientSize", BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo DefaultMaximumSize= instance.GetType().GetProperty("DefaultMaximumSize", BindingFlags.Public | BindingFlags.Instance);
        return instance;
    }
