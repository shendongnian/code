        public static IWebDriver GetDriver(this IWebElement element)
        {
            IWrapsDriver wrappedElement = element as IWrapsDriver;
            if (wrappedElement == null)
            {
                FieldInfo fieldInfo = element.GetType().GetField("underlyingElement", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                {
                    wrappedElement = fieldInfo.GetValue(element) as IWrapsDriver;
                    if (wrappedElement == null)
                        throw new ArgumentException("Element must wrap a web driver", "element");
                }
            }
            return wrappedElement.WrappedDriver;
        }
