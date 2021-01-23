    public partial class Settings
    { 
        internal void SetModel(ModelType model)
        {
            // Check if valid model and throw some type of argument exception if not
            settingsTreeView.Model = model;
        }
    }
