        private void ScrollTextBox(object sender, MouseEventArgs e)
            // Mouse wheel has been turned while text box has focus
        {
            // Check scroll amount (+ve is upwards)
            int deltaWheel = e.Delta;
            if (deltaWheel != 0)
            {
                // Find total number of lines
                int nLines = edtAddress.Lines.Length;
                if (nLines > 0)
                {
                    // Find line containing caret
                    int iLine = edtAddress.GetLineFromCharIndex(edtAddress.SelectionStart);
                    if (iLine >= 0)
                    {
                        // Scroll down
                        if (deltaWheel > 0)
                        {
                            // Move caret to start of previous line
                            if (iLine > 0)
                            {
                                int position = edtAddress.GetFirstCharIndexFromLine(iLine - 1);
                                edtAddress.Select(position, 0);
                            }
                        }
                        else // Scroll up
                        {
                            // Move caret to start of next line
                            if (iLine < (nLines - 1))
                            {
                                int position = edtAddress.GetFirstCharIndexFromLine(iLine + 1);
                                edtAddress.Select(position, 0);
                            }
                        }
                        // Scroll to new caret position
                        edtAddress.ScrollToCaret();
                    }
                }        
             
            } 
        }
