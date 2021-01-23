    XDocument doc = XDocument.Parse(QueryParmeterString);
    XNamespace ns = XNamespace.Get("http://Microsoft.EnterpriseManagement.Core.Criteria/");
    var expressions = (from ds in doc.Root.Descendants(ns + "Expression")
                               select ds).ToList();
            foreach (var foo in expressions)
            {
                XElement expressionTypeElement = foo.FirstNode  as XElement;
                if (expressionTypeElement != null)
                {
                    if (expressionTypeElement.Name.LocalName == "SimpleExpression")
                    {
                        XElement valueExpressionLeft = expressionTypeElement.Element(ns +"ValueExpressionLeft");
                        XElement valueExpressionRight = expressionTypeElement.Element(ns +"ValueExpressionRight");
                        string operator = expressionTypeElement.Element(ns + "Operator").Value;
                        // do your job here 
                        //....
                    }
                    else if (expressionTypeElement.Name.LocalName == "UnaryExpression")
                    {
                        XElement valueExpression = expressionTypeElement.Element(ns +"ValueExpression");
                        // do your job here
                        //....
                    }
                }
            }
