    Partial Public Class TC_Driver
    Friend Function MountVolume(ByVal driveNo As Integer, ByVal volumePath As String, ByVal password As String, ByVal cachePassword As Boolean, ByVal sharedAccess As Boolean, ByRef MountOption As MOUNT_OPTIONS, ByVal quiet As Boolean) As TC_ERROR
        Dim mount As MOUNT_STRUCT
        Dim dwResult As UInteger
        Dim bResult As Boolean, bDevice As Boolean
        Dim favoriteMountOnArrivalRetryCount As Integer = 0
        If IsMountedVolume(volumePath) Then Return TC_ERROR.VOL_ALREADY_MOUNTED
        If Not VolumePathExists(volumePath) Then Return TC_ERROR.FILES_OPEN
        mount = New MOUNT_STRUCT
        mount.VolumePassword = New PASSWORD_STUCT
        mount.ProtectedHidVolPassword = New PASSWORD_STUCT
        mount.bExclusiveAccess = Not sharedAccess
        mount.SystemFavorite = False
        mount.UseBackupHeader = MountOption.UseBackupHeader
        mount.RecoveryMode = MountOption.RecoveryMode
    retry:
        mount.nDosDriveNo = driveNo
        mount.bCache = cachePassword
        mount.bPartitionInInactiveSysEncScope = False
        If StringLen(password) > 0 Then
            mount.VolumePassword = New PASSWORD_STUCT
            mount.VolumePassword.Text = password.PadRight(MAX_PASSWORD + 1, Chr(0))
            mount.VolumePassword.Length = StringLen(password)
            mount.VolumePassword.Pad = "".PadRight(3, Chr(0))
        Else
            mount.VolumePassword = New PASSWORD_STUCT
            mount.VolumePassword.Text = "".PadRight(MAX_PASSWORD + 1, Chr(0))
            mount.VolumePassword.Length = 0
            mount.VolumePassword.Pad = "".PadRight(3, Chr(0))
        End If
        If (Not MountOption.ReadOnly) And MountOption.ProtectHiddenVolume Then
            mount.ProtectedHidVolPassword = New PASSWORD_STUCT
            mount.ProtectedHidVolPassword.Pad = "".PadRight(3, Chr(0))
            MountOption.ProtectedHidVolPassword.ApplyKeyFile(mount.ProtectedHidVolPassword.Text)
            mount.ProtectedHidVolPassword.Length = StringLen(mount.ProtectedHidVolPassword.Text)
            mount.bProtectHiddenVolume = True
        Else
            mount.ProtectedHidVolPassword = New PASSWORD_STUCT
            mount.ProtectedHidVolPassword.Length = 0
            mount.ProtectedHidVolPassword.Text = "".PadRight(MAX_PASSWORD + 1, Chr(0))
            mount.ProtectedHidVolPassword.Pad = "".PadRight(3, Chr(0))
            mount.bProtectHiddenVolume = False
        End If
        mount.bMountReadOnly = MountOption.ReadOnly
        mount.bMountRemovable = MountOption.Removable
        mount.bPreserveTimestamp = MountOption.PreserveTimestamp
        mount.bMountManager = True
        If volumePath.Contains("\\?\") Then volumePath = volumePath.Substring(4)
        If volumePath.Contains("Volume{") And volumePath.LastIndexOf("}\") = volumePath.Length - 2 Then
            Dim resolvedPath As String = VolumeGuidPathToDevicePath(volumePath)
            If Not resolvedPath = "" Then volumePath = resolvedPath
        End If
        mount.wszVolume = volumePath.PadRight(TC_MAX_PATH, Chr(0))
        If Not bDevice Then
            'UNC
            If volumePath.StartsWith("\\") Then
                'Bla bla
            End If
            Dim bps As UInteger, flags As UInteger, d As UInteger
            If GetDiskFreeSpace(Path.GetPathRoot(volumePath), d, bps, d, d) Then
                mount.BytesPerSector = bps
            End If
            If (Not mount.bMountReadOnly) And GetVolumeInformation(Path.GetPathRoot(volumePath), Nothing, 0, Nothing, d, flags, Nothing, 0) Then
                mount.bMountReadOnly = Not (flags And FILE_READ_ONLY_VOLUME) = 0
            End If
        End If
        bResult = DeviceIoControlMount(ManagedDriver.hDriver, TC_IOCTL.MOUNT_VOLUME, mount, Marshal.SizeOf(mount), mount, Marshal.SizeOf(mount), dwResult, Nothing)
        mount.VolumePassword = Nothing
        mount.ProtectedHidVolPassword = Nothing
        If Not bResult Then
            If Marshal.GetLastWin32Error = SYSTEM_ERROR.SHARING_VIOLATION Then
                'TODO
                If Not mount.bExclusiveAccess Then
                    Return TC_ERROR.FILES_OPEN_LOCK
                Else
                    mount.bExclusiveAccess = False
                    GoTo retry
                End If
                Return TC_ERROR.ACCESS_DENIED
            End If
            Return TC_ERROR.GENERIC
        End If
        If Not mount.nReturnCode = 0 Then Return mount.nReturnCode
        'Mount successful
        BroadcastDeviceChange(DBT_DEVICE.ARRIVAL, driveNo, 0)
        If Not mount.bExclusiveAccess Then Return TC_ERROR.OUTOFMEMORY
        Return mount.nReturnCode
    End Function
