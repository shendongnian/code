        public string TempStringBind(string bind)
        {
            DummyLabel.SetBinding(Label.ContentProperty, new Binding(bind));
            return DummyLabel.Content.ToString();
        }
    
       public int TempIntBind(string bind)
        {
            DummyLabel.SetBinding(Label.ContentProperty, new Binding(bind));
    
            int newInt;
            if (DummyLabel.Content != null && int.TryParse(DummyLabel.Content.ToString(), out newInt))
            {
                return newInt;
            }
            else
            {
                return -1;
            }
        }
