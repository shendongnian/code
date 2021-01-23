     private void gridViewOrders_MouseDown (object sender, MouseEventArgs e)
     {
          GridView gv = sender as GridView;
          if (gv != null)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    ShowWaitScreen (message);
                    ...
                    CloseWaitScreen ( )
               }
           }
     }
