    public class ListEx : ListBox {
      protected override void OnSelectedIndexChanged(EventArgs e) {
        base.OnSelectedIndexChanged(e);
        this.RecreateHandle();
      }
    }
