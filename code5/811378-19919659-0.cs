    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using MyEmbbedFile;
    
    namespace ProjectNameSpace
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    var resName = "ProjectNameSpace.MyEmbbedFile.dll";
                    var thisAssembly = Assembly.GetExecutingAssembly();
                    using (var input = thisAssembly.GetManifestResourceStream(resName))
                    {
                        return input != null
                             ? Assembly.Load(StreamToBytes(input))
                             : null;
                    }
                };
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                MyEmbbedFileApp app = new MyEmbbedFileApp();
                app.DoStuff();
            }
    
            private static byte[] StreamToBytes(Stream input)
            {
                var capacity = input.CanSeek ? (int)input.Length : 0;
                using (var output = new MemoryStream(capacity))
                {
                    int readLength;
                    var buffer = new byte[4096];
    
                    do
                    {
                        readLength = input.Read(buffer, 0, buffer.Length);
                        output.Write(buffer, 0, readLength);
                    }
                    while (readLength != 0);
    
                    return output.ToArray();
                }
            }
        }
    }
