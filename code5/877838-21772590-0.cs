     class ChildClass
    {
        public string LabelText { get; set; }
        //Update the above property in suitable method.
        public string ChildMethod()
        {
            LabelText = "XXXX";
        }
    }
     class ParentClass
        {
            public string ParentLabelText { get; set; }
            public string ParentMethod()
            {
                var childObj = new ChildClass();
                DialogResult result = ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    //update your parent each time you are closing the showdialog window.
                    this.ParentLabelText = childObj.LabelText;
                }
            }
        }
