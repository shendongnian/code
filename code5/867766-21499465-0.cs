        public class RequiredArray : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var arr = value as string[];
                if (arr == null)
                {
                    return false;
                }
                foreach (var str in arr)
                    if (!String.IsNullOrWhiteSpace(str))
                        return true;
                return false;
            }
        }
