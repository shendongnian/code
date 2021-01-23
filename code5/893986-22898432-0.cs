    using System.Globalization;
    using System.ComponentModel;
    using System.Threading;
.......
.......
.......
    Thread.CurrentThread.CurrentUICulture = new CultureInfo(DDLLang.SelectedValue);
    ComponentResourceManager resource = new ComponentResourceManager(typeof(Default));
    resource.ApplyResources(LblName, "LblName");
    LblName.ID = "LblName";
    Response.Write(resource.GetString("strMsg",CultureInfo.CurrentUICulture)??resource.GetString("strMsg"));
