    @property (nonatomic, retain) IBOutlet UIButton *Google;
    @synthesize Google = _Google;
    using  MonoTouch . Foundation ; 
    using  System . CodeDom . Compiler ; 
    namespace  Foo . Client . iPhone
    { 
    [ Register  ( "AuthenticationViewController" )] 
    partial  class  AuthenticationViewController 
    { 
        [ Outlet ] 
        MonoTouch . UIKit . UIButton  Google  {  get ;  set ;  } 
        void  ReleaseDesignerOutlets  () 
        { 
            if  ( Google  !=  null )  { 
                Google . Dispose  (); 
                Google  =  null ; 
            } 
           } 
        } 
       }
      using System;
      using System.Drawing;
      using MonoTouch.Foundation;
      using MonoTouch.UIKit;
      namespace Foo.Client.iPhone
     {
     public partial class AuthenticationViewController : UIViewController
     {
        public int xxx = 0;
        public event EventHandler OnAuthenticationCompleted;
        public AuthenticationViewController() 
            : base ("AuthenticationViewController", null)
        {
        }
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Google.TouchUpInside += (sender, e) => 
            {
                xxx++;
            };
        }
       }
       } 2013-10-25 21:37:13.785 FooClientiPhone[8852:1403] MonoTouch: Socket error while           connecting to MonoDevelop on 127.0.0.1:10000: Connection refused
        mono-rt: Stacktrace:
       mono-rt:   at <unknown> <0xffffffff>
      mono-rt:   at (wrapper managed-to-native) MonoTouch.UIKit.UIApplication.UIApplicationMain         (int,string[],intptr,intptr) <IL 0x0009f, 0xffffffff>
      mono-rt:   at MonoTouch.UIKit.UIApplication.Main (string[],string,string) [0x0004c] in /Developer/MonoTouch/Source/monotouch/src/UIKit/UIApplication.cs:38
  
      mono-rt:   at Foo.Client.iPhone.Application.Main (string[]) [0x00008] in /Users/PureKrome/Documents/Mac Projects/Foo iOS Client/Code/Foo.Client.iPhone/Main.cs:16
    mono-rt:   at (wrapper runtime-invoke) <Module>.runtime_invoke_void_object          (object,intptr,intptr,intptr) <IL 0x00050, 0xffffffff>
       mono-rt: 
       Native stacktrace:
      mono-rt: 
       =================================================================
        Got a SIGSEGV while executing native code. This usually indicates
        a fatal error in the mono runtime or one of the native libraries 
            used by your application.
            =================================================================
