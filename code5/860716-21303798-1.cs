        public partial class SelectAccounts : UserControl
        {
            bool _Shown = false;
            private void SelectAccounts_Paint(object sender, PaintEventArgs e)
            {
                if (!this._Shown)
                {
                    this._Shown = true;
                    MessageBox.Show("something");
                }
            }
        }
