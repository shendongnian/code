        public void ChangeTextReflection<T>(T control, string text)
        {
            var info = control.GetType().GetProperty("Text");
            info.SetValue(control, text);
        }
