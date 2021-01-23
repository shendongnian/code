    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    namespace Gists.Extensions.ListOfTExtentions
    {
        public static class ListOfTExtentions
        {
            /// <summary>
            /// Converst this instance to delimited text.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="instance">The instance.</param>
            /// <param name="delimiter">The delimiter.</param>
            /// <param name="trimTrailingNewLineIfExists">
            /// If set to <c>true</c> then trim trailing new line if it exists.
            /// </param>
            /// <returns></returns>
            public static string ToDelimitedText<T>(this List<T> instance, 
                string delimiter, 
                bool trimTrailingNewLineIfExists = false)
                where T : class, new()
            {
                int itemCount = instance.Count;
                if (itemCount == 0) return string.Empty;
                var properties = GetPropertiesOfType<T>();
                int propertyCount = properties.Length;
                var outputBuilder = new StringBuilder();
                for (int itemIndex = 0; itemIndex < itemCount; itemIndex++)
                {
                    T listItem = instance[itemIndex];
                    AppendListItemToOutputBuilder(outputBuilder, listItem, properties, propertyCount, delimiter);
                    AddNewLineIfRequired(trimTrailingNewLineIfExists, itemIndex, itemCount, outputBuilder);
                }
                var output = TrimTrailingNewLineIfExistsAndRequired(outputBuilder.ToString(), trimTrailingNewLineIfExists);
                return output;
            }
            private static void AddDelimiterIfRequired(StringBuilder outputBuilder, int propertyCount, string delimiter,
                int propertyIndex)
            {
                bool isLastProperty = (propertyIndex + 1 == propertyCount);
                if (!isLastProperty)
                {
                    outputBuilder.Append(delimiter);
                }
            }
            private static void AddNewLineIfRequired(bool trimTrailingNewLineIfExists, int itemIndex, int itemCount,
                StringBuilder outputBuilder)
            {
                bool isLastItem = (itemIndex + 1 == itemCount);
                if (!isLastItem || !trimTrailingNewLineIfExists)
                {
                    outputBuilder.Append(Environment.NewLine);
                }
            }
            private static void AppendListItemToOutputBuilder<T>(StringBuilder outputBuilder, 
                T listItem, 
                PropertyInfo[] properties,
                int propertyCount,
                string delimiter)
                where T : class, new()
            {
                
                for (int propertyIndex = 0; propertyIndex < properties.Length; propertyIndex += 1)
                {
                    var property = properties[propertyIndex];
                    var propertyValue = property.GetValue(listItem);
                    outputBuilder.Append(propertyValue);
                    AddDelimiterIfRequired(outputBuilder, propertyCount, delimiter, propertyIndex);
                }
            }
            private static PropertyInfo[] GetPropertiesOfType<T>() where T : class, new()
            {
                Type itemType = typeof (T);
                var properties = itemType.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);
                return properties;
            }
            private static string TrimTrailingNewLineIfExistsAndRequired(string output, bool trimTrailingNewLineIfExists)
            {
                if (!trimTrailingNewLineIfExists || !output.EndsWith(Environment.NewLine)) return output;
                int outputLength = output.Length;
                int newLineLength = Environment.NewLine.Length;
                int startIndex = outputLength - newLineLength;
                output = output.Substring(startIndex, newLineLength);
                return output;
            }
        }
    }
    
