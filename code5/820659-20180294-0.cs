            private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mouseisup == false)
                    {
                        int positionToSearch = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));
                        richTextBox1.SelectionStart = positionToSearch;
                        textBox1.Text = richTextBox1.Text.Substring(positionToSearch, 1);
                        previousChar = positionToSearch;
                        mouseisup = true;//add this statement
                    }
                    else
                    {
                        currentChar = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));
                        if (currentChar > previousChar + 2)
                        {
                            richTextBox1.SelectionStart = currentChar;
                            textBox2.Text = richTextBox1.Text.Substring(currentChar, 1);
                        }
                        currentChar = -1;
                        previousChar = -1;
                        mouseisup = false;
                    }
                }
            }
    
            private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
            {
                mouseisup = true;
            }
