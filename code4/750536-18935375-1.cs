        private static bool _isNetworkDeployed;
        private static bool _isNetworkDeployedChecked;
        public static bool IsNetworkDeployed
        {
            get
            {
                if (!_isNetworkDeployedChecked)
                {
                    _isNetworkDeployed = (
                        AppDomain.CurrentDomain != null &&
                        AppDomain.CurrentDomain.ActivationContext != null &&
                        AppDomain.CurrentDomain.ActivationContext.Identity != null &&
                        AppDomain.CurrentDomain.ActivationContext.Identity.FullName != null);
                    //_isNetworkDeployed = ApplicationDeployment.IsNetworkDeployed;
                    _isNetworkDeployedChecked = true;
                }
                return _isNetworkDeployed;
            }
        }
