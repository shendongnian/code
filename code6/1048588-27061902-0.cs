    string TryGetImageName()
    {
        if (GetImageNameFunc != null)
        {
            string imageName = GetImageNameFunc();
            if (!string.IsNullOrEmpty(imageName))
            {
                return imageName;
            }
        }
        return null; //no default!
    }
    
    string GetImageNameOrDefault() {
     return TryGetImageName() ?? "default.png";
    }
