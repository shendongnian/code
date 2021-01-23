    var parstyle = new MonoTouch.UIKit.NSMutableParagraphStyle ();
    parstyle.Alignment = MonoTouch.UIKit.UITextAlignment.Justified;
    var att = new NSMutableAttributedString (billboard.Desc);
    att.AddAttribute (
    	MonoTouch.UIKit.UIStringAttributeKey.ParagraphStyle,
    	parstyle,
    	new NSRange (0, att.Length)
    );
    att.AddAttribute (
    	MonoTouch.UIKit.UIStringAttributeKey.Font,
    	MonoTouch.UIKit.UIFont.FromName ("Parangon110C", 11),
    	new NSRange (0, att.Length)
    	);
    DescLabel.AttributedText = att;
