    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Globalization;
    using System.Resources;
    using System.IO;
    using System.Xml;
    public partial class UpdateResource : System.Web.UI.Page
    {
        public int indexNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string resourcespath = Request.PhysicalApplicationPath + "App_GlobalResources";
                //DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
                //foreach (FileInfo filInfo in dirInfo.GetFiles())
                //{
                //    string filename = filInfo.Name;
                //    cmbResources.Items.Add(filename);
                //}
                //cmbResources.Items.Insert(0, new ListItem("Select a Resource File"));
                string[] filePaths = Directory.GetFiles(@"C:\Users\D1956\Desktop\ResourceEdit", "*.aspx");
                foreach (string file in filePaths)
                {
                    string[] f = file.Split(new char[] { '\\' });
                    cmbResources.Items.Add(f[f.Length - 1]);
                }
            }
        }
        protected void cmbResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResources.SelectedIndex != 0)
            {
                string filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + cmbResources.SelectedItem.Text;
                Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                ResXResourceReader RrX = new ResXResourceReader(stream);
                IDictionaryEnumerator RrEn = RrX.GetEnumerator();
                SortedList slist = new SortedList();
                while (RrEn.MoveNext())
                {
                    slist.Add(RrEn.Key, RrEn.Value);
                }
                RrX.Close();
                stream.Dispose();
                gridView1.DataSource = slist;
                gridView1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + cmbResources.SelectedItem.Text;
            string filename1 = filename.Remove(filename.Length - 5);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNodeList nlist = xmlDoc.GetElementsByTagName("data");
            for (int i = 0; i < gridView1.Items.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gridView1.Items[i].FindControl("chkRow");
                if (chkItem.Checked)
                {
                    XmlNode childnode = nlist.Item(i);
                    XmlNode lastnode = childnode.SelectSingleNode("value");
                    TextBox txtTran = (TextBox)gridView1.Items[i].FindControl("txtTrans");
                    lastnode.InnerText = txtTran.Text.ToString();
                }
            }
            xmlDoc.Save(filename1 + "_1" + ".resx");
        }
    }
