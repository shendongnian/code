    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim getMethod As New DecimalDegreesToDegreesMinutesSeconds
        getMethod.PointFromScreenPoint(X, Y)
    End Sub
        Public Class DecimalDegreesToDegreesMinutesSeconds
    ' Used by both
    Private pSpRFc As ESRI.ArcGIS.Geometry.SpatialReferenceEnvironment
    ' WGS1984
    Private pSpRef1 As ESRI.ArcGIS.Geometry.ISpatialReference
    Private pGCS As ESRI.ArcGIS.Geometry.IGeographicCoordinateSystem
    '' NAD83 FEET STATEPLANES NC 
    'Private pSpRef2 As ESRI.ArcGIS.Geometry.ISpatialReference
    'Private pPCS As ESRI.ArcGIS.Geometry.IProjectedCoordinateSystem
    Private ReadOnly Property WGS84() As ESRI.ArcGIS.Geometry.ISpatialReference
        Get
            ' WGS1984
            pSpRFc = New ESRI.ArcGIS.Geometry.SpatialReferenceEnvironment
            pGCS = pSpRFc.CreateGeographicCoordinateSystem(4326)
            pSpRef1 = pGCS
            pSpRef1.SetFalseOriginAndUnits(-180, -90, 1000000)
            Return pSpRef1
        End Get
    End Property
    ' pass the original screen point into this function
    Public Sub PointFromScreenPoint(pX As Double, pY As Double)
        Dim scrDisp As ESRI.ArcGIS.Display.IScreenDisplay = Nothing
        Dim pnt As ESRI.ArcGIS.Geometry.IPoint = Nothing
        Dim pGeoSpRef As ESRI.ArcGIS.Geometry.IGeometry = Nothing
        Try
            '
            scrDisp = New ESRI.ArcGIS.Display.ScreenDisplay
            scrDisp = SGProperties.pActiveView.ScreenDisplay ' the activeview
            scrDisp.StartDrawing(scrDisp.hDC, CShort(ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache))
            '
            pnt = scrDisp.DisplayTransformation.ToMapPoint(pX, pY)
            '
            pGeoSpRef = pnt
            pGeoSpRef.SpatialReference = SGProperties.pMap.SpatialReference ' the current maps
            pGeoSpRef.Project(WGS84())
            Windows.Forms.MessageBox.Show("X position is " + ConvertDegrees(pnt.X, DegreesType.Longitude).ToString() + " Y position is " + ConvertDegrees(pnt.Y, DegreesType.Latitude).ToString())
        Catch ex As Exception
        Finally
            If scrDisp IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(scrDisp)
            scrDisp = Nothing
            If pnt IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(pnt)
            pnt = Nothing
            If pGeoSpRef IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(pGeoSpRef)
            pGeoSpRef = Nothing
        End Try
    End Sub
    Enum DegreesType
        Latitude
        Longitude
    End Enum
    Private Function ConvertDegrees(pInDegrees As Double, pInType As DegreesType)
        Dim degrees As Integer
        Dim submin As Double
        Dim minutes As Double
        Dim subsecsonds As Double
        Dim direction As String
        Dim output As String
        Try
            degrees = Math.Truncate(pInDegrees)
            submin = Math.Abs((pInDegrees - Math.Truncate(pInDegrees)) * 60)
            minutes = Math.Truncate(submin)
            subsecsonds = Math.Abs((submin - Math.Truncate(submin)) * 60)
            direction = ""
            If pInType.ToString().Trim().ToUpper() = "Latitude".ToUpper() Then
                If degrees < 0 Then
                    direction = "S"
                ElseIf (degrees > 0) Then
                    direction = "N"
                Else
                    direction = ""
                End If
            ElseIf pInType.ToString().Trim().ToUpper() = "Longitude".ToUpper() Then
                If degrees < 0 Then
                    direction = "W"
                ElseIf (degrees > 0) Then
                    direction = "E"
                Else
                    direction = ""
                End If
            End If
            output = degrees.ToString() + ":" + minutes.ToString() + ":" + subsecsonds.ToString().Substring(0, 5) + direction
            Return output
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
