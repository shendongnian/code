    public class PanelEx : Panel {
      protected override Point ScrollToControl(Control activeControl) {
        //return base.ScrollToControl(activeControl);
        return this.AutoScrollPosition;
      }
    }
