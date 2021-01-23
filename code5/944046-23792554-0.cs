        [Conditional("DEBUG"), DebuggerStepThrough()]
        public void VerifyPropertyName(string propertyName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this);
            var objValue = properties[propertyName].GetValue(this);
            if (objValue == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                else
                {
                    Debug.Fail(msg);
                }
            }
        }
