    public class MyControl : Button {
      private ToolTip _toolTip;
      private string _tip;
      public MyControl() {
        _toolTip = new ToolTip();
        _toolTip.UseAnimation = false;
        _toolTip.UseFading = false;
        _toolTip.ShowAlways = true;
        _toolTip.AutoPopDelay = 0;
        _toolTip.Active = true;
      }
      public string ToolTip {
        get { return _tip; }
        set {
          _tip = value;
          _toolTip.SetToolTip(this, _tip);
        }
      }
    }
