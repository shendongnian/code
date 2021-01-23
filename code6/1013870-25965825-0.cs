    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    
    namespace COPS_Photo_Viewer
    {
        public partial class CPV : Form
        {
            public CPV()
            {
                InitializeComponent();
    
                textIP.Text = Dns.GetHostAddresses(Dns.GetHostName())[0].MapToIPv4().ToString();
                textID.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                textMachine.Text = Dns.GetHostName();
                textApplication.Text = Application.ProductName;
            }
    
            private Image ExtractImage(byte[] binary)
            {
                int start = 0;
                for (; start < binary.Length; ++start)
                    if (((char)binary[start]) == 'ÿ')
                        break;
    
                byte[] image = new byte[binary.Length - start];
                for (int index = start; index < binary.Length; ++index)
                    image[index - start] = binary[index];
    
                return Bitmap.FromStream(new MemoryStream(image));
            }
    
            private void GetImage(Object sender, EventArgs args)
            {
                WebResponse response = Request();
                byte[] input = ReadStream(response.GetResponseStream());
                photograph.Image = ExtractImage(input);
            }
    
            private XmlDocument GetXml()
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(...);
                return xml;
            }
    
            private byte[] ReadStream(Stream stream)
            {
                Queue<byte> input = new Queue<byte>();
                byte[] buffer = new byte[1];
    
                for (int read = stream.ReadByte(); read >= 0; read = stream.ReadByte())
                    input.Enqueue((byte)read);
    
                return input.ToArray<byte>();
            }
    
            private WebResponse Request()
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(Validate);
                System.Security.Cryptography.X509Certificates.X509Certificate certificate =
                System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile("wmbuat.crt");
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textURL.Text);
                request.Headers.Add("SOAP:Action");
                request.ContentType = "text/xml";
                request.Accept = "text/xml";
                request.Method = "POST";
                request.ClientCertificates.Add(certificate);
    
                GetXml().Save(request.GetRequestStream());
                return request.GetResponse();
            }
    
            private static Boolean Validate(Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            }
        }
    }
