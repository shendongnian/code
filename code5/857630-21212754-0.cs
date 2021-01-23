    public class CustomCell : UITableViewCell
    {
        public CustomCell(UITableViewCellStyle style, NSString reuseIdentifier) : base(style, reuseIdentifier)
        {
        }
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            // do something
            base.TouchesBegan(touches, evt);
        }
    }
