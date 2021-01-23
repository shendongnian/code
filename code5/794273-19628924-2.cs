      [AttributeUsage(AttributeTargets.All,AllowMultiple=true)]
        public class CustomFeaturePermissionAttribute : ActionFilterAttribute
        {
            private FeatureValue[] feature;
            private PermissionValue[] permission;
            private bool excludeParamId;
            /// <summary>
            /// Set values of featurelist and permission list
            /// </summary>
            /// <param name="featureList"></param>
            /// <param name="permissionList"></param>
            public CustomFeaturePermissionAttribute(object featureList,object permissionList, int excludeParamId)
            {
                FeatureList = (FeatureValue[])featureList;
                PermissionList = (PermissionValue[])permissionList;
                ExcludeParamId = excludeParamId;
            }
            public FeatureValue[] FeatureList
            {
                get
                {
                    return feature;
                }
                set
                {
                    feature = value;
                }
            }
    
            public bool ExcludeParamId
            {
                get
                {
                    return excludeParamId;
                }
                set
                {
                    excludeParamId = value;
                }
            }
    
            public PermissionValue[] PermissionList
            {
                get
                {
                    return permission;
                }
                set
                {
                    permission = value;
                }
            }
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
    
                bool isAccessAllowed = false;
                FeatureValue feature;
                PermissionValue permission;
                for (int i = 0; i < FeatureList.Count(); i++)
                {
                    feature = FeatureList[i];
                    permission = PermissionList[i];
                        isAccessAllowed = UserPermission.VerifyPermission(feature, permission, Convert.ToInt16(ExcludeParamId));
                   
                    if (isAccessAllowed)
                        break;
                }
    
                if (!isAccessAllowed)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnauthorizedAccess", controller = "Security" }));
                } 
              
            }
        }
