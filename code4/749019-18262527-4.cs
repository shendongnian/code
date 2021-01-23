    Private Sub Updater_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Updater.Tick
        ' Move the mouse (relatively) 1 pixel away and then back
        MoveMouse(1, 1, MOUSEEVENTF_MOVE)
        MoveMouse(-1, -1, MOUSEEVENTF_MOVE)
    End Sub
