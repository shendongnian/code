    public class BaseForm: Form
    {
      private static Bitmap _skin = new Bitmap(@"default");
      // base Form stores static image which should be set as background for derived forms
      public static Bitmap Skin 
      {
        get { return _skin; }
        set { _skin = value; OnSkinChanged(EventArgs.Empty); }
      }
    
      // when current image changes, event is raised
      static event EventHandler SkinChanged;
    
      static void OnSkinChanged(EventArgs e)
      {
        if (SkinChanged!=null)
            SkinChanged(null, e);
      }
    
      public BaseForm()
      {
         InitializeComponent();
         // all derived forms are subscribed to event of changing background image
         // they update own background image
         BaseForm.SkinChanged += SetSkinHandler;
         // set background when form created
         if (!DesignMode) // do not change in design mode (optional check)
            SetSkin();     
      }
    
      private void SetSkinHandler(object sender, EventArgs e)
      {
        SetSkin();
      }
    
      private void SetSkin()
      {
        this.BackgroundImage = BaseForm.Skin;
      }
      protected override void Dispose(bool disposing)
      {
            if (disposing)
            {
                BaseForm.SkinChanged -= SetSkinHandler;
            }
            // default
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
      }
    }
    
