     using Microsoft.WindowsAPICodePack.Shell;
        private void ListExtendedProperties(string filePath)
        {
            var file = ShellObject.FromParsingName(filePath);
            var i = 0;
            foreach (var property in file.Properties.DefaultPropertyCollection)
            {
                var name = (property.CanonicalName ?? "unnamed-[" + i + "]").Replace("System.", string.Empty);
                var t = Nullable.GetUnderlyingType(property.ValueType) ?? property.ValueType;
                var value = (null == property.ValueAsObject)
                    ? string.Empty
                    : (Convert.ChangeType(property.ValueAsObject, t)).ToString();
                var friendlyName = property.Description.DisplayName;
                Console.WriteLine(i++ + " " + name + "/" + friendlyName + ": " + value);
            }
        }
