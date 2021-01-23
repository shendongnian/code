        public List<MyContainer> MyNavigationArray;
        public void InitArray()
        {
            MyNavigationArray = new List<MyContainer>(MyFormPageCount);
            for (int i = 0; i < MyFormPageCount; i++)
            {
                MyNavigationArray.Add(new MyContainer(TheNameOfUserControl, new PredefinedUserControl()));
            }
        }
        private void NextButton_click(object sender, EventArgs e)
        {
            MyContainer mYcn = this.panel1.Controls[0] as  MyContainer;
            int nCurPos = MyNavigationArray.IndexOf(mYcn);
            if (nCurPos < MyNavigationArray.Count)
            {
                panel1.Controls.Clear();
                MyContainer c = MyNavigationArray[nCurPos + 1];
                panel1.Controls.Add(c);
                c.Dock = DockStyle.Fill;
            }
         }
