    public static readonly DependencyProperty NoteProperty = 
        DependencyProperty.Register("Note", typeof (string), 
        typeof (YourObject), new PropertyMetadata(String.Empty, UpdateDetails));
        private static void UpdateDetails(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var o = (YourObject)d;
            d.UpdateDetails();
        }
        private void UpdateDetails()
        {
            string strInfo;
            strInfo = Resources.SharedOn + ": " + DateString;
            strInfo += "\n" + Resources.Access + ": " + AccessString;
            if (ExpiryString != Resources.ShareExpireNever)
            {
                strInfo += "\n" + Resources.ShareExpire + ": " + ExpiryString;
            }
            if (Note != null && Note != "")
            {
                strInfo += "\n" + Resources.ShareNote + ": " + Note;
            }
            Details = strInfo;
        }
