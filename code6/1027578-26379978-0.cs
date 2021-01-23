        public void CreateMdiChild(Form child)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            child.MdiParent = this;
            child.Dock = DockStyle.Fill;
            child.Show();
        }
