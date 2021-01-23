            protected void CopyEntityObject<T>(ref T old, ref T updated)
        {
            var propInfo = old.GetType().GetProperties();
            foreach (var item in propInfo)
            {
                if (item.CanWrite)
                {
                    old.GetType().GetProperty(item.Name).SetValue(old, item.GetValue(updated, null), null);
                }
            }
        }
