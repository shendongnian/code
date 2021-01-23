      GrapeCity.ActiveReports.SectionReport sectionReport = new GrapeCity.ActiveReports.SectionReport();
        sectionReport.Sections.Add(GrapeCity.ActiveReports.Document.Section.SectionType.Detail, "Body");
                    GrapeCity.ActiveReports.SectionReportModel.TextBox MyTextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
                    MyTextBox.Text = "My Runtime Text";
                    MyTextBox.ShrinkToFit = true;
                    MyTextBox.DataField = "ID";
                    sectionReport.Sections[0].Controls.Add(MyTextBox);
