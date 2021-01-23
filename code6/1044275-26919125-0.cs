        foreach (var pdfform in pdfPagesID)
        {
            //dbAutoTrack.PDFWriter.Document objDoc = null;
            //dbAutoTrack.PDFWriter.Page objPage = null;
            objDoc = new dbAutoTrack.PDFWriter.Document();
            pdfPagesID.Clear();
            pdfPagesID = GetSpecPageID(pdfform);
            if (pdfPagesID.Count > 1)
            {
                foreach (var pdfPage in pdfPagesID)
                {
                    dbAutoTrack.PDFWriter.Page objPage2 = null;
                    var lastItem = pdfPagesID.Last();
                    prefixPageID = prefixSpecPageID(pdfPage);
                    suffixPageIDPSR = prefixPageID + ".psr";
                    if (File.Exists(PSRPath + suffixPageIDPSR))
                    {
                        objDs = new CDatasheet(this.PSRPath + suffixPageIDPSR, false);
                        objDs.pdfDbHelper = pdfhelper;
                        //Giving the specformId as SpecFornName
                       pdfFormName = "Form" + pdfform + ".pdf";
                        if (!(pdfPage == pdfPagesID.First()))
                        {
                            objPage2 = objDs.Generate_PDFReport();
                            objDoc.Pages.Add(objPage2);
                        }
                        else
                        {
                            objPage = objDs.Generate_PDFReport();
                            objDoc.Pages.Add(objPage);
                        }
                        if (objPage != null)
                        {
                            if (pdfWithNotePage == true && pdfPage.Equals(lastItem))
                            {
                                objNotePage = objDs.GetNotePage();
                                objDoc.Pages.Add(objPage);
                                objDoc.Pages.Add(objNotePage);
                            }
                            else
                            {
                                //objDoc.Pages.Add(objPage);
                                //objDoc.Pages.Add(objPage2);
                            }
         }
        }
        }
                            fsOutput = new FileStream(TemplatePath + pdfFormName, FileMode.Create, FileAccess.Write);
                            objDoc.Generate(fsOutput);
                         //This region was the problem, disposing the output everytime.
                    //Needed it to be included after completion of iteration
                        if (fsOutput != null)
                        {
                            fsOutput.Close();
                            fsOutput.Dispose();
                            fsOutput = null;
                        }
                     }
