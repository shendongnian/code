    public override String StyleSheetTheme
    {
        get 
        { 
            string theme = "";
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "en-US":
                    theme = "YourTheme1"; break;
                case "nl-NL":
                    theme = "YourTheme2"; break;
            }
            return theme;
        }
    }
