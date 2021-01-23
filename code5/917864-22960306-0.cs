try
{
    //Your OutOfMemoryException code here
}
catch(Exception ex)
{
    ScriptManager.RegisterStartupScript(yourControlId, yourControlId.GetType(), "tabs" , "jsMEthodName('"+ ex.Message +"')");
}
