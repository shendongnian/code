        private void addFinalCheckdata()
        {
            PdfPTable table = new PdfPTable(10);
            float[] widths = new float[] { 60f, 60f, 60f, 60f, 60f, 60f, 60f, 60f, 260f, 60f };
            table.TotalWidth = 800f;
            table.SetWidths(widths);
            table.LockedWidth = true;
            table.HorizontalAlignment = 0;
            
            // Add Answers 
            //string value = _LGSRobj.finalCheck.SatisfactoryVisualInspection;
            PdfPCell cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 1
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.EmergencyControl;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 2
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.EarthBondingSatisfactory;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 3
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.NumberofAppliancesTested;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 4
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.serviceTimerSet;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 5
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.StartPressure;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 6
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.FinishPressure;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 7
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.Pass;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 8
            table.AddCell(cell);
            //value = _LGSRobj.finalCheck.InstallationCaped;
            cell = new PdfPCell(new Phrase("z", _fntNormal7));
            // 9
            table.AddCell(cell);
            _document.Add(table);
        }
