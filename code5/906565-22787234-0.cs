        /// <summary>
        /// Refresh the Page.
        /// </summary>
        /// <typeparam name="T">Page.</typeparam>
        public void Refresh<T>() where T : Page, new()
        {
            Type t = typeof(T);
            PropertyInfo pi = this.GetType().GetProperty(t.Name);
            pi.SetValue(this, new T(), null);
        }
