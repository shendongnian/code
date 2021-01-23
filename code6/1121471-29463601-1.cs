    XmlDocument doc = new XmlDocument();
    doc.LoadXML("<Messages> 
               <Exceptions />  
                   <ValidationIssues>
                       <ValidationMessage Message=\"The Customer Communication requires a value for Search Phone or Email.\" FriendlyMessage=\"\" />  
                    </ValidationIssues>
             </Messages>"  );
  
    String str = doc.SelectSingleNode("//Messages/ValidationIssues/ValidationMessage").Attributes["Message"].Value;
