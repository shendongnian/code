                    MenuItem mi = new MenuItem("Cut");
                    mi.Click += new EventHandler(mi_Cut);
                    cm.MenuItems.Add(mi);
                    mi = new MenuItem("Copy");
                    mi.Click += new EventHandler(mi_Copy);
                    cm.MenuItems.Add(mi);
                    mi = new MenuItem("Paste");
                    mi.Click += new EventHandler(mi_Paste);
                    cm.MenuItems.Add(mi);
                    
                    richTextBox.ContextMenu = cm;
                    //Code to add right click
                   void mi_Cut(object sender, EventArgs e)
                   {
                    richTextBox..Cut();
                   }
               
    
                   void mi_Copy(object sender, EventArgs e)        
                  {
                    Graphics objGraphics;
                    Clipboard.SetData(DataFormats.Rtf, richTextBox..SelectedRtf);
                    Clipboard.Clear();
                  }
                  void mi_Paste(object sender, EventArgs e)
                  {
                    if (Clipboard.ContainsText(TextDataFormat.Rtf))
                    {
                        richTextBox.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
                    }
    
                 }
                
