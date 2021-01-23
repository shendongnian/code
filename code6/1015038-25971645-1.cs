    try
    {
        string hely = @"C:\Program Files (x86)\FileZilla Server\FileZilla Server.xml";
        StreamWriter wr = new StreamWriter(hely, false);
        wr.WriteLine("<FileZillaServer>");
        wr.WriteLine("      <Settings>");
        wr.WriteLine("       <Item name=\"Admin port\" type=\"numeric\">14147</Item>");
        wr.WriteLine("   </Settings>");
        wr.WriteLine("  <Groups />");
        wr.WriteLine("  <Users>");
        wr.WriteLine(" <User Name=\"test\">");
        wr.WriteLine("      <Option Name=\"Pass\">test</Option>");
        wr.WriteLine("       <Option Name=\"Group\"></Option>");
        wr.WriteLine("      <Option Name=\"Bypass server userlimit\">0</Option>");
        wr.WriteLine("       <Option Name=\"User Limit\">0</Option>");
        wr.WriteLine("      <Option Name=\"IP Limit\">0</Option>");
        wr.WriteLine("     <Option Name=\"Enabled\">1</Option>");
        wr.WriteLine("      <Option Name=\"Comments\">test</Option>");
        wr.WriteLine("      <Option Name=\"ForceSsl\">0</Option>");
        wr.WriteLine("   <IpFilter>");
        wr.WriteLine("      <Disallowed />");
        wr.WriteLine("      <Allowed />");
        wr.WriteLine("  </IpFilter>");
        wr.WriteLine("  <Permissions>");
        wr.WriteLine("       <Permission Dir=\"D:\\FTP_Root\">");
        wr.WriteLine("      <Option Name=\"FileRead\">1</Option>");
        wr.WriteLine("     <Option Name=\"FileWrite\">1</Option>");
        wr.WriteLine("       <Option Name=\"FileDelete\">1</Option>");
        wr.WriteLine("       <Option Name=\"FileAppend\">1</Option>");
        wr.WriteLine("       <Option Name=\"DirCreate\">1</Option>");
        wr.WriteLine("      <Option Name=\"DirDelete\">1</Option>");
        wr.WriteLine("      <Option Name=\"DirList\">0</Option>");
        wr.WriteLine("      <Option Name=\"DirSubdirs\">1</Option>");
        wr.WriteLine("      <Option Name=\"IsHome\">1</Option>");
        wr.WriteLine("       <Option Name=\"AutoCreate\">0</Option>");
        wr.WriteLine("    </Permission>");
        wr.WriteLine("  </Permissions>");
        wr.WriteLine("<SpeedLimits DlType=\"0\" DlLimit=\"10\" ServerDlLimitBypass=\"0\" UlType=\"0\" UlLimit=\"10\" ServerUlLimitBypass=\"0\">");
        wr.WriteLine("              <Download />");
        wr.WriteLine("          <Upload />");
        wr.WriteLine("       </SpeedLimits>");
        wr.WriteLine(" </User>");
        wr.WriteLine("  </Users>");
        wr.WriteLine("</FileZillaServer>");
        wr.Close();
        string pathtofilezilla = @"C:\Program Files (x86)\FileZilla Server";
        Process.Start("CMD.exe", "/C \"" + pathtofilezilla + "\\FileZilla Server.exe\" /reload-config");
    }
    catch (Exception ex)
    {
        throw ex;
    }
