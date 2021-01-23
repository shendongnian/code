          private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {   //click event
                        //MessageBox.Show("you got it!");
                        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                        MenuItem menuItem = new MenuItem("Cut");
                        menuItem.Click += new EventHandler(CutAction);
                        contextMenu.MenuItems.Add(menuItem);
                        menuItem = new MenuItem("Copy");
                        menuItem.Click += new EventHandler(CopyAction);
                        contextMenu.MenuItems.Add(menuItem);
                        menuItem = new MenuItem("Paste");
                        menuItem.Click += new EventHandler(PasteAction);
                        contextMenu.MenuItems.Add(menuItem);
        
                        richTextBox1.ContextMenu = contextMenu;
                    }
                }
                void CutAction(object sender, EventArgs e)
                {
                    richTextBox1.Cut();
                }
        
                void CopyAction(object sender, EventArgs e)
                {
                    Graphics objGraphics;
                    Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);
                    Clipboard.Clear();
                }
        
                void PasteAction(object sender, EventArgs e)
                {
                    if (Clipboard.ContainsText(TextDataFormat.Rtf))
                    {
                        richTextBox1.SelectedRtf
                            = Clipboard.GetData(DataFormats.Rtf).ToString();
                    }
                } 
