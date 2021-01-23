    class classAA<T> : List<T> where T : classC
    {
        public void SomeMethod()
        {
            foreach (var item in this.Cast<classC>())
            {
                // here you can call item.DrawObject()
            }
        }
    }
