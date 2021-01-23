        private delegate void BlankDelegate();
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new BlankDelegate(this.CloseForm));
            }
            else
            {
                this.Close();
            }
        }
