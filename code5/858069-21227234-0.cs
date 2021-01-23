        [__DynamicallyInvokable]
        public bool EndsWith(string value)
        {
          return this.EndsWith(value, string.LegacyMode ? StringComparison.Ordinal : StringComparison.CurrentCulture);
        }
