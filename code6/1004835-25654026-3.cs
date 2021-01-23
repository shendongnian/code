    private void ChangeText(object target)
    {
        var textProperty = target.GetType().GetProperty("Text");
        if (textProperty != null)
        {
            try
            {
                target.GetType().GetProperty("Text").SetValue(target, "New Value", null);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException
                    || ex is MethodAccessException
                    || ex is TargetInvocationException)
                {
                    // Unable to set the property for whatever reason
                    return;
                }
                // All other exceptions -- something unexpected happened.
                throw;
            }
        }
    }
