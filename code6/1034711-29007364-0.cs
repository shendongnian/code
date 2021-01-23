            DataTable dt = GetDataTableFromDGV(AFIs, ArrayTitle, ArrayEnTitle, ArrayOrder, ArrayChecked);       
            DataView dataView = dt.DefaultView;
            report.ScriptLanguage = StiReportLanguageType.CSharp;
            report.RegData("view", dataView);
            //fill dictionary
            report.Dictionary.Synchronize();
            StiPage page = report.Pages.Items[0];
            if (Landscape)
                page.Orientation = StiPageOrientation.Landscape;
            else
                page.Orientation = StiPageOrientation.Portrait;
            //
            Double pos = 0;
            //Double columnWidth = StiAlignValue.AlignToMinGrid(page.Width / dataView.Table.Columns.Count, 0.1, true);
            Double columnWidth = StiAlignValue.AlignToMinGrid(page.Width / dt.Columns.Count, 0.1, true);
            int nameIndex = 1;
            columnWidth = StiAlignValue.AlignToMinGrid(page.Width / dt.Columns.Count, 0.1, true);
            //create ReportTitleBand
            StiReportTitleBand rt = new StiReportTitleBand();
            rt.Height = 1.5f;
            rt.Name = "ReportTitleBand";
            StiText st = new StiText(new RectangleD(0, 0, page.Width, 1f));
            st.Text.Value = ReportTitle;
            st.HorAlignment = StiTextHorAlignment.Center;
            st.Name = "TitleText1";
            st.Font = new Font(FontName, 16f);
            rt.Components.Add(st);
            page.Components.Add(rt);
            //create HeaderBand
            StiHeaderBand headerBand = new StiHeaderBand();
            if (chkRotate)
                headerBand.Height = 0.9f;
            else
                headerBand.Height = 0.5f;
            headerBand.Name = "HeaderBand";
            page.Components.Add(headerBand);
            //create Dataaband
            StiDataBand dataBand = new StiDataBand();
            dataBand.DataSourceName = "view" + dataView.Table.TableName;
            dataBand.Height = 0.5f;
            dataBand.Name = "DataBand";
            dataBand.CanBreak = true;//Added 11 20 2014     
            page.Components.Add(dataBand);
            //create FooterBand
            StiFooterBand footerBand = new StiFooterBand();
            footerBand.Height = 0.5f;
            footerBand.Name = "FooterBand";
            footerBand.Border = new StiBorder(StiBorderSides.All, Color.Black, 1, StiPenStyle.Solid);
            footerBand.PrintOnAllPages = true;            
            page.Components.Add(footerBand);            
            pos = (page.Width - (columnWidth * Convert.ToDouble(dataView.Table.Columns.Count))) / Convert.ToDouble(2);
            for (int i = dataView.Table.Columns.Count - 1; i != -1; i--)
            {
                DataColumn column = dataView.Table.Columns[i];
                //initilized column value
                Double headerHeight = 0.5f;
                if (chkRotate)
                    headerHeight = 0.9f;
                StiText headerText = new StiText(new RectangleD(pos, 0, columnWidth, headerHeight));
                headerText.Text.Value = Stimulsoft.Report.CodeDom.StiCodeDomSerializator.ReplaceSymbols(column.Caption).Replace("_", " ");//ReplaceUnderLineWithSpace(column.Caption);
                if (chkRotate)
                    headerText.Angle = 90;
                headerText.HorAlignment = StiTextHorAlignment.Center;
                headerText.VertAlignment = StiVertAlignment.Center;
                headerText.Name = "HeaderText" + nameIndex.ToString();
                headerText.Brush = new StiSolidBrush(Color.LightGreen);
                headerText.Border.Side = StiBorderSides.All;
                headerBand.Components.Add(headerText);
                headerText.Font = new Font(FontName, 11.0f);
                headerText.WordWrap = true;
                headerText.GrowToHeight = true;
                //initilized Data Band value
                StiText dataText = new StiText(new RectangleD(pos, 0, columnWidth, 0.5f));
                dataText.Text.Value = "{view" + dataView.Table.TableName + "." + Stimulsoft.Report.CodeDom.StiCodeDomSerializator.ReplaceSymbols(column.ColumnName) + "}";
                dataText.Name = "DataText" + nameIndex.ToString();
                dataText.HorAlignment = StiTextHorAlignment.Center;
                dataText.VertAlignment = StiVertAlignment.Center;
                dataText.Border.Side = StiBorderSides.All;
                dataText.WordWrap = true;
                dataText.GrowToHeight = true;
                dataText.Font = new Font(FontName, 11.0f);                
                //Add highlight
                if (true)
                {
                    StiCondition condition = new StiCondition();
                    condition.BackColor = Color.CornflowerBlue;
                    condition.TextColor = Color.Black;
                    condition.Expression = "(Line & 1) == 1";
                    condition.Font = new Font(FontName, 11.0f);
                    condition.Item = StiFilterItem.Expression;
                    dataText.Conditions.Add(condition);
                }
                dataBand.Components.Add(dataText);
                pos += columnWidth;
                nameIndex++;
            }
            ////footer text
            StiText footerText = new StiText(new RectangleD(0, 0, page.Width, 0.5f));
            footerText.Text.Value = "صفحه {PageNumber}";
            footerText.HorAlignment = StiTextHorAlignment.Center;
            footerText.Name = "FooterText";
            footerText.Brush = new StiSolidBrush(Color.WhiteSmoke);
            footerText.Font = new Font(FontName, 11.0f);
            footerBand.Components.Add(footerText);
            report.Render(true);
            StiWebViewer1.ResetReport();
            StiWebViewer1.Report = report;
