    using System;
    
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using Gesture = Android.Glass.Touchpad.Gesture;
    using GestureDetector = Android.Glass.Touchpad.GestureDetector;
    
    
    namespace GlassGestureTest
    {
        using Android.Util;
    
        using Java.Util.Logging;
    
        [Activity(Label = "GlassGestureTest", MainLauncher = true, Icon = "@drawable/icon")]
        public class Activity1 : Activity
        {
    
            private GestureDetector _gestureDetector;
    
            int count = 1;
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                // Get our button from the layout resource,
                // and attach an event to it
                Button button = FindViewById<Button>(Resource.Id.MyButton);
    
                button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
    
                this._gestureDetector = new GestureDetector(this);
                this._gestureDetector.SetBaseListener(new GestureListener());
            }
    
            public override bool OnGenericMotionEvent(MotionEvent e)
            {
                if (this._gestureDetector != null)
                {
                    return this._gestureDetector.OnMotionEvent(e);  
                }
    
                return false;
            }
        }
        
        // Note - the key part here is to extend Java.Lang.Object in order to properly setup
        // the IntPtr field and Dispose method required by IBaseListener
        public class GestureListener : Java.Lang.Object, GestureDetector.IBaseListener
        {
            public bool OnGesture(Gesture gesture)
            {
                if (gesture == Gesture.SwipeRight)
                {
                    // do something on right (forward) swipe
                    return true;
                }
                else if (gesture == Gesture.SwipeLeft)
                {
                    // do something on left (backwards) swipe
                    return true;
                }
                else if (gesture == Gesture.SwipeDown)
                {
                    // do something on the down swipe
                    return true;
                }
                else if (gesture == Gesture.SwipeUp)
                {
                    // do something on the up swipe
                    return true;
                }
    
                return false;
            }
        }
    }
