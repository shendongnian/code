    public static bool ValidateAndSave(this WorkItem wit)
    {
        bool valid = wit.IsValid();
        if (valid)
        {
            wit.Save();
        }
        else
        {
            string msg = "Error saving work item, validation failed ! Errors: " + Environment.NewLine;
            foreach (var field in wit.Validate().Cast<Field>())
            {
                msg += "Field " + field.Name + " has status " + field.Status + Environment.NewLine;
            }
            EventLog.WriteEntry("WemTfsSubSystem", msg);
        }
        return valid;
    }
