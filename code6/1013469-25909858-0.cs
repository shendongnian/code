    class ParentForm : Form
    {
        public static string Name = "SomeName";
    }
    class ChildForm : Form
    {
        private void SomeMethod()
        {
            var parentName = ParentForm.Name;
        }
    }
