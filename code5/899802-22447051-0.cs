    // Create a definition for the extended property.
    ExtendedPropertyDefinition extendedPropertyDefinition = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "Engineer", MapiPropertyType.String);
    // Create an e-mail message that you will add the extended property to.
    EmailMessage message = new EmailMessage(service);
    message.Subject = "Saved with custom ExtendedPropertyDefinition.";
    message.Body = "The Engineer custom value is stored within the extended property.";
    message.ToRecipients.Add("user@contoso.com");
    // Add the extended property to an e-mail message object.
    message.SetExtendedProperty(extendedPropertyDefinition, "Save some customer value");
    message.Save();
