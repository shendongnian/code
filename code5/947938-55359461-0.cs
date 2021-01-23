`
using cs_pdf_to_image;
using PdfToImage;
`
`
        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string PdfFile = openFileDialog1.FileName;
                    string PngFile = "Convert.png";
                    List<string> Conversion = cs_pdf_to_image.Pdf2Image.Convert(PdfFile, PngFile);
                    Bitmap Output = new Bitmap(PngFile);
                    PbConversion.Image = Output;
                }
                catch(Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
        }
`
