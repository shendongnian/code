        using Android.Views.InputMethods;
        using Xamarin.Forms.Platform.Android;
            public class EditorRender : EditorRenderer
            {
                protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
                {
                    this.Id = 1111111908; //some id i can remember
                    base.OnElementChanged(e); // when the control actually gets created
                    
                }
            }
