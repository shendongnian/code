    using System;
    using System.Drawing;
    using MonoMac.Foundation;
    using MonoMac.AppKit;
    
    namespace MonoMacTest02
    {
        public class AppDelegate : NSApplicationDelegate
        {
            public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
            {
                // Get the button
                var closeButton = CreateCloseButton ();
                // Get size and create rectangle for the view                 
                var closeButtonSize = closeButton.Frame.Size;
                var closeButtonRect = new RectangleF (8, 8, closeButtonSize.Width, closeButtonSize.Height);
                // Apply the rectangle to the frame
                closeButton.Frame = closeButtonRect;
                // Attach an event to the button. When "Activated" / "Clicked" it will close the application.
                closeButton.Activated += (object sender, EventArgs e) => { 
                    NSApplication.SharedApplication.Terminate(closeButton);
                };
    
                // Creating the NSWindow object
                var window = new NSWindow (
                    new RectangleF(0, 0, 400, 300), // Sets the size of the window
                    NSWindowStyle.Titled, // Style of the window
                    NSBackingStore.Buffered,
                    false
                ) {
                    // Adding a title
                    Title = "MonoMacTest02 (Adding a button)"
                };
    
                // Add our button to the window
                // AddSubView expects an NSView object. All UI controls are derived from NSView, so we can add the 'closeButton' itself.
                window.ContentView.AddSubview (closeButton);
                window.CascadeTopLeftFromPoint (new PointF (20, 20));
                window.MakeKeyAndOrderFront (null);
            }
    
            // Creating the button
            private NSButton CreateCloseButton() {
                var closeButton = new NSButton ();
                closeButton.Title = "Close";
                closeButton.BezelStyle = NSBezelStyle.Rounded;
    
                closeButton.SizeToFit ();
    
                return closeButton;
            }
        }
    }
