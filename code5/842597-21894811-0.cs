        protected override bool ProcessConstraint(System.Web.HttpContextBase httpContext, object constraint, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool retValue = false;
            string contraintName = constraint.GetType().Name;
            if (httpContext.Items != null && httpContext.Items.Contains(contraintName))
            {
                //Inspect list of constraints to override
                if (httpContext.Items.Contains(constraint.GetType().Name))
                    bool.TryParse(httpContext.Items[constraint.GetType().Name].ToString(), out retValue);
            }
            else
            {
                retValue = base.ProcessConstraint(httpContext, constraint, parameterName, DecodeValues(values), routeDirection);
            }
            
            return retValue;
        }
