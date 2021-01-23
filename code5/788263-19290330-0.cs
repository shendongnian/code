          private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
               popupMenu1.Manager.Bars[0].Tag = false;
          }
           using DevExpress.XtraBars;
           using DevExpress.XtraBars.ViewInfo;
    
            public class MyBarManager : BarManager {
                protected override BarSelectionInfo CreateSelectionInfo() {
                    return new MyBarSelectionInfo(this);
                }
            }
        
            public class MyBarSelectionInfo : BarSelectionInfo {
                public MyBarSelectionInfo(BarManager manager)
                    : base(manager) {
                }
        
                public override void ClosePopup(IPopup popup) {
                    if (!(bool)Manager.Bars[0].Tag) {
                        Manager.Bars[0].Tag = true;
                        return;
                    }
                    
                    base.ClosePopup(popup);
                }
            }
