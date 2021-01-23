    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using ios = System.Runtime.InteropServices;
    
    namespace ClipBoardTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public void ExportRangeAsJpg()
            {
                Excel.Application xl;
    
                xl = (Excel.Application)ios.Marshal.GetActiveObject("Excel.Application");
    
                if (xl == null)
                {
                    MessageBox.Show("No Excel !!");
                    return;
                }
    
                Excel.Workbook wb = xl.ActiveWorkbook;
                Excel.Range r = wb.ActiveSheet.Range["A1:E10"];
                r.CopyPicture(Excel.XlPictureAppearance.xlScreen,
                               Excel.XlCopyPictureFormat.xlBitmap);
                
                 if (Clipboard.GetDataObject() != null)
                {
                    IDataObject data = Clipboard.GetDataObject();
    
                    if (data.GetDataPresent(DataFormats.Bitmap))
                    {
                        Image image = (Image)data.GetData(DataFormats.Bitmap, true);
                        this.pict1.Image = image;
                        image.Save(@"C:\_Stuff\test\sample.jpg",
                            System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        MessageBox.Show("No image in Clipboard !!");
                    }
                }
                else
                {
                    MessageBox.Show("Clipboard Empty !!");
                }  
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ExportRangeAsJpg();
            }
    
    
    
        }
    }
