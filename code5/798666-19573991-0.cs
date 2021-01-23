    /// <summary>
    /// Replaces invalid XML characters in a string with their valid XML equivalent.
    /// </summary>
    /// <param name="xmlString">The XML string.</param>
    /// <returns>Valid Xml</returns>
    public static string ReplaceInvalidXml(string xmlString)
    {
        return System.Security.SecurityElement.Escape(xmlString);
    }
