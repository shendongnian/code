        private void CheckForNull(object obj)
        {
            if (!ReferenceEquals(obj, null))
            {
                return;
            }
            throw new Exception();
        }
