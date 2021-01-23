    using System.Drawing;
    using System.Net;
    using System.IO;
    using System.Windows.Forms;
    WebClient wc = new WebClient();                
    using (MemoryStream ms = new MemoryStream(wc.DownloadData(customItem.FullURL))) {
        Image img = Image.FromStream(ms);
        MessageBox.Show(img.Height.ToString() + " -- " + img.Width.ToString());
    }
