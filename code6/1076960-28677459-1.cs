    using System;
    using MyApp;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    [assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
    namespace MyApp.Android
    {
        class CustomEditorRenderer : EditorRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
            {
                base.OnElementChanged(e);
                int androidId = this.Id; // android widget id
                Guid xamarinId = e.NewElement.Id; // xamarin view id
            }
        }
    
