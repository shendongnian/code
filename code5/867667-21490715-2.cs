        private CheckAgainstDataDelegate _isFieldValid;
        public CheckAgainstDataDelegate IsFieldValid
        {
            get
            {
                return _isFieldValid
                    ?? (_isFieldValid = delegate (object newValue,string propertyName)
                    {
                        switch (propertyName)
                        {
                            case "TargetPosition":
                                var newV = (int) newValue;
                                return Items.All(e => e.TargetPosition != newV);
                            default:
                                throw  new Exception("Property Assigned to unknown field");
                        }
                    });
            }
        }
