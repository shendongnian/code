     private void timer1_Tick(object sender, EventArgs e)
        {
        
            y = GetActiveWindowTitle();
        
            try
            {
                Microsoft.Office.Interop.Word.Application WordObj;
                WordObj = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                var vvv = WordObj.StartupPath;
                    x = "";
                    for (int i = 0; i < WordObj.Windows.Count; i++)
                    {
                        object idx = i + 1;
                        Microsoft.Office.Interop.Word.Window WinObj = WordObj.Windows.get_Item(ref idx);
                        
                        // doc_list.Add(WinObj.Document.FullName);
                        x = x + "," + WinObj.Document.FullName;
                        //x = WinObj.Document.FullName;
                    }                                                         
            }
            catch (Exception ex)
            {
                // No documents opened
            }
            
            string[] ax=x.Split(',');
          //  string[] ax1 = x1.Split(',');
           
            
           
            ForAllWordFiles.Text = x;
            ForWordTitle.Text = y;
            if (y != null)
            {
                ActiveWord.Text = " ";
                if (y.Contains("- Microsoft Word"))
                {
                    ForWordTitle.Text = y.Substring(0, y.Length - 17);
                    foreach (var item in ax)
                    {
                        if (item.Contains(ForWordTitle.Text))
                        {
                            ActiveWord.Text = item;
                            break;
                        }
                        ActiveWord.Text = " ";
                    }
                }
            }
        }
