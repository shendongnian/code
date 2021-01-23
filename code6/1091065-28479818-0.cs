    public class BaseForm: Form
    {
      private static Bitmap _skin = new Bitmap(@"default");
      public static Bitmap Skin 
      {
        get { return _skin; }
        set { _skin = value; OnSkinChanged(EventArgs.Empty); }
      }
    
      static event EventHandler SkinChanged;
    
      static void OnSkinChanged(EventArgs e)
      {
        if (SkinChanged!=null)
            SkinChanged(null, e);
      }
    
      public BaseForm()
      {
         BaseForm.SkinChanged += SetSkinHandler;
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
    }
    
