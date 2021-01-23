protected void Page_Load(object sender, EventArgs e)
{
    MasterPageObject m = (MasterPageObject)base.Master;
    m.masterPageMethod += customMethod;
}
private void customMethod(object sender, EventArgs e)
{
    // Your processing here
}
