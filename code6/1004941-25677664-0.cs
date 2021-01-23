    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    
    namespace TouchButtonApp
    {
        public class TouchButton : Button
        {
            DoubleAnimationUsingKeyFrames _animation;
            bool _isCancelled = false;
    
            public static readonly DependencyProperty DelayElapsedProperty =
             DependencyProperty.Register("DelayElapsed", typeof(double), typeof(TouchButton), new PropertyMetadata(0d));
    
            public static readonly DependencyProperty DelayMillisecondsProperty =
                    DependencyProperty.Register("DelayMilliseconds", typeof(int), typeof(TouchButton), new PropertyMetadata(Properties.Settings.Default.ButtonTouchDelay));
    
            public static readonly DependencyProperty IsTouchedProperty =
     DependencyProperty.Register("IsTouched", typeof(bool), typeof(TouchButton), new PropertyMetadata(false));
    
    
            // Create a custom routed event by first registering a RoutedEventID 
            // This event uses the bubbling routing strategy 
            public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
                "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TouchButton));
    
    
            public TouchButton()
            {
                this.TouchDown +=TouchButton_TouchDown;
                this.TouchUp +=TouchButton_TouchUp;
            }
    
            // Provide CLR accessors for the event 
            public event RoutedEventHandler Tap
            {
                add { AddHandler(TapEvent, value); }
                remove { RemoveHandler(TapEvent, value); }
            }
    
            // This method raises the Tap event 
            void RaiseTapEvent()
            {
                if (!_isCancelled)
                {
                    //Console.Beep();
                    this.IsTouched = true;
                    Console.WriteLine("RaiseTapEvent");
                    RoutedEventArgs newEventArgs = new RoutedEventArgs(TouchButton.TapEvent);
                    RaiseEvent(newEventArgs);
                }
            }
    
            public bool IsTouched
            {
                get { return (bool)this.GetValue(IsTouchedProperty); }
                set { this.SetValue(IsTouchedProperty, value); }
            }
    
            public double DelayElapsed
            {
                get { return (double)this.GetValue(DelayElapsedProperty); }
                set { this.SetValue(DelayElapsedProperty, value); }
            }
    
            public int DelayMilliseconds
            {
                get { return (int)this.GetValue(DelayMillisecondsProperty); }
                set { this.SetValue(DelayMillisecondsProperty, value); }
            }
            
            //Start the animation and raise the event unless its cancelled
            private void BeginDelay()
            {
                _isCancelled = false;
                Console.WriteLine("BeginDelay ");
                this._animation = new DoubleAnimationUsingKeyFrames() { FillBehavior = FillBehavior.Stop };
                this._animation.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0)), new CubicEase() { EasingMode = EasingMode.EaseIn }));
                this._animation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(this.DelayMilliseconds)), new CubicEase() { EasingMode = EasingMode.EaseIn }));
                this._animation.Completed += (o, e) =>
                {
                    this.DelayElapsed = 0d;
                    //this.Command.Execute(this.CommandParameter);    // Replace with whatever action you want to perform     
                    
                    RaiseTapEvent();
                    this.IsTouched = false;
                };
    
                this.BeginAnimation(DelayElapsedProperty, this._animation);
            }
    
            private void CancelDelay()
            {
                // Cancel animation
                _isCancelled = true;
                Console.WriteLine("CancelDelay ");
                this.BeginAnimation(DelayElapsedProperty, null);
            }
            private void TouchButton_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
            {
                this.BeginDelay();
            }
    
            private void TouchButton_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
            {
                this.CancelDelay();
            }
    
        }
    }
