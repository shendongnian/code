        public static IWebElement Parent(this IWebElement elem)
        {
            var script = new[]
            {
                "return",
                "  (function(elem) {",
                "     return elem.parentNode;",
                "   })(arguments[0]);"
            };
            var remoteWebElement = elem as RemoteWebElement;
            if (remoteWebElement == null)
                throw new NotSupportedException("This method is only supported on RemoteWebElement instances. Got: {0}".FormatWith(elem.GetType().Name));
    
            var scriptTxt = script.Implode(separator: " ");
            var scriptExecutor = remoteWebElement.WrappedDriver as IJavaScriptExecutor;
            if (scriptExecutor == null)
                throw new NotSupportedException("This method is only supported on drivers implementing IJavaScriptExecutor interface. Got: {0}".FormatWith(elem.GetType().Name));
    
            return scriptExecutor.ExecuteScript(scriptTxt, elem) as IWebElement;
        }
    
        public static ReadOnlyCollection<IWebElement> Parents(this IWebElement elem, string selector = null)
        {
            var script = new[]
            {
                "return",
                "  (function(elem) {",
                //"     console.log(elem);",
                "     var result = [];",
                "     var p = elem.parentNode;",
                "     while (p && p != document) {",
                //"       console.log(p);",
                (string.IsNullOrWhiteSpace(selector) ? null :
                    "     if (p.matches && p.matches('" + selector + "'))"),
                "          result.push(p);",
                "       p = p.parentNode;",
                "     }",
                "     return result;",
                "   })(arguments[0]);"
            };
            var remoteWebElement = elem as RemoteWebElement;
            if (remoteWebElement == null)
                throw new NotSupportedException("This method is only supported on RemoteWebElement instances. Got: {0}".FormatWith(elem.GetType().Name));
            
            var scriptTxt = script.Implode(separator: " ");
            var scriptExecutor = remoteWebElement.WrappedDriver as IJavaScriptExecutor;
            if (scriptExecutor == null)
                throw new NotSupportedException("This method is only supported on drivers implementing IJavaScriptExecutor interface. Got: {0}".FormatWith(elem.GetType().Name));
    
            var resultObj = scriptExecutor.ExecuteScript(scriptTxt, elem) as ReadOnlyCollection<IWebElement>;
            if (resultObj == null)
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            return resultObj;
        }
    
        public static IWebElement Closest(this IWebElement elem, string selector)
        {
            var script = new[]
            {
                "return",
                "  (function(elem) {",
                "     var p = elem;",
                "     while (p && p != document) {",
                "       if (p.matches && p.matches('" + selector + "'))",
                "          return p;",
                "       p = p.parentNode;",
                "     }",
                "     return null;",
                "   })(arguments[0]);"
            };
            var remoteWebElement = elem as RemoteWebElement;
            if (remoteWebElement == null)
                throw new NotSupportedException("This method is only supported on RemoteWebElement instances. Got: {0}".FormatWith(elem.GetType().Name));
    
            var scriptTxt = script.Implode(separator: " ");
            var scriptExecutor = remoteWebElement.WrappedDriver as IJavaScriptExecutor;
            if (scriptExecutor == null)
                throw new NotSupportedException("This method is only supported on drivers implementing IJavaScriptExecutor interface. Got: {0}".FormatWith(elem.GetType().Name));
    
            return scriptExecutor.ExecuteScript(scriptTxt, elem) as IWebElement;
        }
