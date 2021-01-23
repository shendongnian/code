        private Expression BuildExpression(Expression parentExpression,
            Type parentPropertyType, string pathOfChildProperty)
        {
            string remainPathOfChild;
            var childPropertyName = 
                  GetFirstPropertyNameFromPathAndRemainPath(pathOfChildProperty, out remainPathOfChild);
            if (string.IsNullOrEmpty(childPropertyName)) return parentExpression;
            var childPropInfo = parentPropertyType.GetProperty(childPropertyName);
            var childExpression = Expression.Property(parentExpression, childPropInfo);
            return !string.IsNullOrEmpty(remainPathOfChild)
                ? BuildExpressionForInternalProperty(childExpression, childPropInfo.PropertyType, remainPathOfChild)
                : childExpression;
        }
        private string GetFirstPropertyNameFromPathAndRemainPath(string path, out string remainPath)
        {
            if (string.IsNullOrEmpty(path))
            {
                remainPath = null;
                return null;
            }
            var indexOfDot = path.IndexOf('.');
            if (indexOfDot < 0)
            {
                remainPath = null;
                return path;
            }
            remainPath = path.Substring(indexOfDot + 1);
            return path.Substring(0, indexOfDot);
        }
        }
