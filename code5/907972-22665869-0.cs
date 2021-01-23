        private PropertyInfo GetProperty([CallerMemberName] string name = "")
        {
            var myPropertyInfo = this.GetType().GetProperty(name);
            return myPropertyInfo;
        }
