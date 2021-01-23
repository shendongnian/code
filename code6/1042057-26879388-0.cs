    Dim sr As New GrapeCity.ActiveReports.SectionReport()
    sr = Me.reportdesigner.Report
    ''Adding Detail section
    sr.Sections.Insert(1, New GrapeCity.ActiveReports.SectionReportModel.Detail())
    sr.Sections(1).BackColor = Color.PeachPuff
    sr.Sections(1).Height = 1.5F
    Dim lbl2 As New GrapeCity.ActiveReports.SectionReportModel.Label()
    lbl2.Location = New PointF(0, 0.05F)
    lbl2.Text = "Category ID"
    lbl2.Alignment = GrapeCity.ActiveReports.Document.Section.TextAlignment.Center
    lbl2.Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
    sr.Sections(1).Controls.Add(lbl2)
