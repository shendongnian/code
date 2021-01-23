    Window win;
        private void Show_PopupToolTip(object sender, MouseEventArgs e)
        {
            var fred = ((Image)sender).TemplatedParent;
            if (fred != null)
            {
                ContentControl c = fred as ContentControl;
                string myText = c.ToolTip.ToString();
                if (!String.IsNullOrEmpty(myText))
                {
                    if (win == null || !win.IsVisible)
                        win = new Window();
                    win.Height = 275;
                    win.Width = 275;
                    win.Content = myText;
                    win.Show();
                }
            }
        }
        private void Hide_PopupToolTip(object sender, MouseEventArgs e)
        {
            //if (win != null)
            //{
            //    win.Close();
            //}
        }
