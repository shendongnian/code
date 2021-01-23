    void Body_MouseDown(object sender, HtmlElementEventArgs e)
                {
                    switch (e.MouseButtonsPressed)
            {
                    
                case MouseButtons.Left:
                    HtmlElement element = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                    if (element != null)
                    {
                        string s = element.Style;
                        if ((s != null) && (s.IndexOf(".png") != -1)) MessageBox.Show("Image Was Clicked");
                    }
                    break;
            }       
                }
