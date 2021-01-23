    public TableCell()
    {
         UIButton btn = new UIButton(UIButtonType.RoundRect);
         btn.TouchUpInside += (sender, args)
         {
               new UIAlertView("Button pressed!", indexPath.Row, null, "OK", null).Show();
         }
    }
