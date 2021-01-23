    var invalidFields = workItem.Validate();
    if (invalidFields.Count > 0)
    {
        foreach (Field field in invalidFields)
        {
            string errorMessage = string.Empty;
            if (field.Status == FieldStatus.InvalidEmpty)
            {
                errorMessage = string.Format("{0} {1} {2}: TF20012: field \"{3}\" cannot be empty."
                    , field.WorkItem.State
                    , field.WorkItem.Type.Name
                    , field.WorkItem.TemporaryId
                    , field.Name);
            }
            //... more handling here
            Console.WriteLine(errorMessage);
        }
    }
    else // Validation passed
    {
        workItem.Save();
    }
