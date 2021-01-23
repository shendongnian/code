    using System.IO;
    using System.Reflection;
    
    try
    {
        //The code that causes the error goes here.
    }
    catch (ReflectionTypeLoadException ex)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Exception exSub in ex.LoaderExceptions)
        {
            sb.AppendLine(exSub.Message);
            if (exSub is FileNotFoundException)
            {
                FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                if(!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                {
                    sb.AppendLine("Fusion Log:");
                    sb.AppendLine(exFileNotFound.FusionLog);
                }
            }
            sb.AppendLine();
        }
        string errorMessage = sb.ToString();
        //Display or log the error based on your application.
    }
