    using (IfxConnection con = new IfxConnection(WebConfigurationManager.AppSettings["LOKICONN"].ToString()))
    {
        con.Execute("update oe_cnvwrk set cwr_response = ?cwr_response?, cwr_uom = ?cwr_uom? where cwr_genero = ?cwr_genero? and cwr_line = ?cwr_line?", attributesList);
        return "success";
    }
