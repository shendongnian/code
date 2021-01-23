    using System;
    using System.IO;
    using System.Text;
    public class XMLWriter
    {
        //Objs
        private StreamWriter sw;
        private StringBuilder sb;
        //static items
        private string strHeader;
        private string strFooter;
    
        public XMLWriter()
        {
            //this is the constructor, what you call with "new XMLWriter()"
        }
    
        public void export(string filename)       
        {
            sb = new StringBuilder();
            sw = new StreamWriter(filename);
            sw.Write(strHeader + sb.ToString() + strFooter);
            sw.Close();
            sw.Dispose();
        }
        public string Footer
        {
            set
            {
                strFooter = value;
            }
        }
        public string Header
        {
            set
            {
                strHeader = value;
            }
        }
        public string LinesAdd
        {
            set
            {
                sb.Append(value);
            }
        }
    }
