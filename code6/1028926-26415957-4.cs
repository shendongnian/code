            TransformDataAttribute attr = Utility.GetPropertyAttribute<TransformDataAttribute>(pi);
            if (attr != null)
            {
                object[] parms = new object[] { value, pi };
                value = Utility.CallThisMethod(attr.TransformDataClass, attr.TransformDataMethod, parms);
            }
            pi.SetValue(t, value, null);
