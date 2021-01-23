    using System;
    using Foundation;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.Binding.iOS.Views;
    using SWTableViewCells;
    using UIKit;
    
    namespace SubViews
    {
        public partial class SampleTableViewCell : SWTableViewCell, IMvxBindable
        {
        public static readonly NSString Key = new NSString ("SampleTableViewCell");
        public static readonly UINib Nib;
    
        public IMvxBindingContext BindingContext { get; set; }
    
        public object DataContext 
        {
            get { return BindingContext.DataContext; }
            set { BindingContext.DataContext = value; }
        }
    
        static SampleTableViewCell ()
        {
            Nib = UINib.FromName ("SampleTableViewCell", NSBundle.MainBundle);
        }
    
        public static SampleTableViewCell Create ()
        {
            return (SampleTableViewCell)Nib.Instantiate (null, null) [0];
        }
    
        public SampleTableViewCell (string bindingText, IntPtr handle)
            : base(handle)
        {
            this.CreateBindingContext (bindingText);
        }
    
        protected SampleTableViewCell (IntPtr handle) : this (string.Empty, handle)
        {
            this.DelayBind (() => {
                var bindings = this.CreateBindingSet<SampleTableViewCell, Type> ();
                //Custom Bindings
                bindings.Apply ();
            });
        }
    }
