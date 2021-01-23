    private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
    {
      GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
      if (hi.InRowCell)
      {
        string text = "Row " + hi.RowHandle.ToString();
        e.Info = new ToolTipControlInfo(hi.RowHandle, text);
      }
    }
