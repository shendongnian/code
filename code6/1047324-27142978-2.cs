        private void RunOnce(ref bool flag, Action callback)
        {
            if (!flag)
            {
                try
                {
                    flag = true;
                    callback();
                }
                finally
                {
                    flag = false;
                }
            }
        }
        private bool inMirror;
        private void realText_TextChanged(object sender, EventArgs e)
        {
            RunOnce(ref inMirror, () =>
            {
                mirrorText.Text = mirror(realText.Text);
            });
        }
        private void mirrorText_TextChanged(object sender, EventArgs e)
        {
            RunOnce(ref inMirror, () =>
            {
                realText.Text = mirror(mirrorText.Text);
            });
        }
        private string mirror(string text)
        {
            return new string(text.Reverse().ToArray()).Replace("\n\r", "\r\n");
        }
