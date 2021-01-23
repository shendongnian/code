            foreach (FieldInfo field in depedencyObjectType.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (field.FieldType == typeof (DependencyProperty))
                {
                    var dp = field.GetValue(depedencyObject) as DependencyProperty;
                    depedencyObject.ClearValue(dp);
                }
            }
