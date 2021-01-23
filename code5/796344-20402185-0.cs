     public string ImagePath
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ImagePath"),defaultPath);
            }
            set
            {
                SetValue("ImagePath", value);
            }
        }
