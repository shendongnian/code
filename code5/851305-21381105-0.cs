    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using Word = Microsoft.Office.Interop.Word;
    using Excel = Microsoft.Office.Interop.Excel;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    using Microsoft.Office.Core;
    
    namespace Sobiens.Connectors.Common
    {
        public static class officeConverter
        {
            public enum officeApplication { Word, Excel, PowerPoint };
    
            private static Dictionary<string, officeDestination> destinationDictionary = new Dictionary<string, officeDestination> {
            {".doc",new officeDestination(officeApplication.Word,".docx",Word.WdSaveFormat.wdFormatXMLDocument)},
            {".dot",new officeDestination(officeApplication.Word,".dotx",Word.WdSaveFormat.wdFormatFlatXMLTemplate)},
            {".xls",new officeDestination(officeApplication.Excel,".xlsx",Excel.XlFileFormat.xlOpenXMLWorkbook)},
            {".xlt",new officeDestination(officeApplication.Excel,".xltx",Excel.XlFileFormat.xlOpenXMLTemplate)},
            {".ppt",new officeDestination(officeApplication.PowerPoint,".pptx",PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation)},
            {".pot",new officeDestination(officeApplication.PowerPoint,".potx",PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLTemplate)}
            };
    
            public static bool convertToNewOfficeDocument(string fileName, out string newFileName)
            {
                string ext;
                return convertToNewOfficeDocument(fileName, out newFileName, out ext);
            }
    
            public static bool convertToNewOfficeDocument(string fileName, out string newFileName, out string newExt)
            {
                string ext = Path.GetExtension(fileName);
                newExt = ext;
    
    
                newFileName = fileName;
    
    
                if (!destinationDictionary.ContainsKey(ext)) return false;
    
                officeDestination dest = destinationDictionary[ext];
                newExt = dest.Extension;
    
                newFileName = fileName.Replace(ext, dest.Extension);
    
                object obj;
    
                bool result = true;
    
                switch (dest.Application)
                {
                    case officeApplication.Word:
                        Word._Application wordApp = new Word.Application();
                        Word._Document wordDoc = null;
    
                        try
                        {
                            wordDoc = wordApp.Documents.Open(fileName);
                            wordDoc.Convert();
                            wordDoc.SaveAs(newFileName, dest.FileFormat);
    
                        }
                        catch (Exception e)
                        {
                            displayError(fileName, e);
                            newFileName = fileName;
                            result = false;
                        }
                        finally
                        {
                            wordDoc.Close();
                            wordApp.Quit();
                            obj = (object)wordDoc;
                            disposeInteropObject(ref obj);
                            obj = (object)wordApp;
                            disposeInteropObject(ref obj);
                        }
                        break;
                    case officeApplication.Excel:
                        Excel._Application excelApp = new Excel.Application();
                        Excel._Workbook excelDoc = null;
                        try
                        {
                            excelDoc = excelApp.Workbooks.Open(fileName);
                            excelDoc.SaveAs(newFileName, dest.FileFormat);
                        }
                        catch (Exception e)
                        {
                            displayError(fileName, e);
                            newFileName = fileName;
                            result = false;
                        }
                        finally
                        {
                            excelDoc.Close();
                            excelApp.Quit();
                            obj = (object)excelDoc;
                            disposeInteropObject(ref obj);
                            obj = (object)excelApp;
                            disposeInteropObject(ref obj);                        
                        }
                        break;
                    case officeApplication.PowerPoint:
                        PowerPoint._Application powerpointApp = new PowerPoint.Application();
                        PowerPoint._Presentation powerpointDoc = null;
                        try
                        {
                            powerpointDoc = powerpointApp.Presentations.Open(fileName, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
                            powerpointDoc.SaveAs(newFileName, (PowerPoint.PpSaveAsFileType)dest.FileFormat);
    
                        }
                        catch (Exception e)
                        {
                            displayError(fileName, e);
                            newFileName = fileName;
                            result = false;
                        }
                        finally
                        {
                            powerpointDoc.Close();
                            powerpointApp.Quit();
                            obj = (object)powerpointDoc;
                            disposeInteropObject(ref obj);
                            obj = (object)powerpointApp;
                            disposeInteropObject(ref obj);
                        }
                        break;
    
    
                }
    
                GC.Collect();
                return result;
            }
    
            private static void displayError(string fileName, Exception e)
            {
                MessageBox.Show("Le fichier \"" + fileName + "\" n'à pu être converti\n" + e.Message,
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /// <summary>
            /// dispose interop object
            /// </summary>
            /// <param name="o">object to dispose</param>
            private static void disposeInteropObject(ref object o)
            {
                if (o != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                o = null;
            }
    
            private class officeDestination
            {
                public officeApplication Application;
                public string Extension;
                public object FileFormat;
    
                public officeDestination(officeApplication application, string extension, object fileFormat)
                {
                    Application = application;
                    Extension = extension;
                    FileFormat = fileFormat;
                }
    
            }
        }
    }
