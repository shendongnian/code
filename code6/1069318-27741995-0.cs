     public delegate void Action();
        private void UpdateUI(object txt)
        {
            this.BeginInvoke((Action)(() =>
            {
                label2.Text = (string)txt;
            })); 
        }
