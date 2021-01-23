     private void ShowMessageBoxIcon(MessageBoxIcon iconSet)
        {
            switch (iconSet)
            {
                case MessageBoxIcon.Asterisk:
                    PictureBoxIconImage.Image =  Bitmap.FromHicon(SystemIcons.Asterisk.Handle);
                    break;
                case MessageBoxIcon.Error:
                    PictureBoxIconImage.Image = Bitmap.FromHicon(SystemIcons.Error.Handle);
                /*
                 * Add remaining icons here
                 * 
                 */
            }
           }
            this.ButtonCancel.Text = rightButton
          }
