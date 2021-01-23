    Delegate Sub UpdateCallback(Volume As Integer, Muted As Boolean)
    Public Overloads Sub Update(Volume As Integer, Muted As Boolean)
        If tbVolume.InvokeRequired Then
            Dim d As New UpdateCallback(AddressOf Update)
            Me.Invoke(d, Volume, Muted)
        Else
            tbVolume.Value = Volume
            _Mute = Muted
            btnMuteUnmute.BackgroundImage = DirectCast(If(_Mute, _
               My.Resources.mute, My.Resources.Unmute), Icon).ToBitmap
        End If
    End Sub
